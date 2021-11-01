﻿using UnityEngine;
using UnityEditor;
using System;
using UnityEditor.IMGUI.Controls;
using HeurekaGames.AssetHunterPRO.BaseTreeviewImpl.AssetTreeView;
using HeurekaGames.AssetHunterPRO.BaseTreeviewImpl;

//Only avaliable in 2018
#if UNITY_2018_1_OR_NEWER
using UnityEditor.Build.Reporting;
#endif

namespace HeurekaGames.AssetHunterPRO
{
    public class AH_Window : EditorWindow
    {
        public const int WINDOWMENUITEMPRIO = 11;

        public const string VERSION = "2.1.3";
        private static AH_Window m_window;

        [NonSerialized] bool m_Initialized;
        [SerializeField] TreeViewState m_TreeViewState; // Serialized in the window layout file so it survives assembly reloading
        [SerializeField] MultiColumnHeaderState m_MultiColumnHeaderState;

        internal static AH_BuildInfoManager GetBuildInfoManager()
        {
            if (!m_window)
                initializeWindow();

            return m_window.buildInfoManager;
        }

        SearchField m_SearchField;
        private AH_TreeViewWithTreeModel m_TreeView;

        [SerializeField]
        public AH_BuildInfoManager buildInfoManager;
        public bool m_BuildLogLoaded { get; set; }

        //Button guiContent
        [SerializeField] GUIContent guiContentLoadBuildInfo;
        [SerializeField] GUIContent guiContentSettings;
        [SerializeField] GUIContent guiContentGenerateReferenceGraph;
        [SerializeField] GUIContent guiContentDuplicates;
        

        //Only avaliable in 2018
#if UNITY_2018_1_OR_NEWER
        [SerializeField] GUIContent guiContentBuildReport;
#endif
        [SerializeField] GUIContent guiContentReadme;
        [SerializeField] GUIContent guiContentDeleteAll;
        [SerializeField] GUIContent guiContentRefresh;

        //UI Rect
        Vector2 uiStartPos = new Vector2(10, 50);
        public static float ButtonMaxHeight = 18;

        //Add menu named "Asset Hunter" to the window menu  
        [UnityEditor.MenuItem("Window/Heureka/Asset Hunter PRO/Asset Hunter PRO _%h", priority = WINDOWMENUITEMPRIO)]
        public static void OpenAssetHunter()
        {
            if (!m_window)
                initializeWindow();
        }

        private static AH_Window initializeWindow()
        {
            //Open ReadMe
            Heureka_PackageDataManagerEditor.SelectReadme();

            m_window = EditorWindow.GetWindow<AH_Window>();

            AH_TreeViewSelectionInfo.OnAssetDeleted += m_window.OnAssetDeleted;
#if UNITY_2018_1_OR_NEWER
            EditorApplication.projectChanged += m_window.OnProjectChanged;
#elif UNITY_5_6_OR_NEWER
            EditorApplication.projectWindowChanged += m_window.OnProjectChanged;
#endif

            if (m_window.buildInfoManager == null)
                m_window.buildInfoManager = ScriptableObject.CreateInstance<AH_BuildInfoManager>();

            m_window.initializeGUIContent();

            //Subscribe to changes to list of ignored items
            AH_SettingsManager.Instance.IgnoreListUpdatedEvent += m_window.OnIgnoreListUpdatedEvent;

            return m_window;
        }

        private void OnEnable()
        {
            AH_SerializationHelper.NewBuildInfoCreated += onBuildInfoCreated;
        }

        private void OnDisable()
        {
            AH_SerializationHelper.NewBuildInfoCreated -= onBuildInfoCreated;
        }
        
        void OnInspectorUpdate()
        {
            if (!m_window)
                initializeWindow();
        }

        void OnGUI()
        {
            /*if (Application.isPlaying)
                return;*/

            InitIfNeeded();
            doHeader();

            if (buildInfoManager == null || !buildInfoManager.HasSelection)
            {
                doNoBuildInfoLoaded();
                return;
            }

            if (buildInfoManager.IsProjectClean() && ((AH_MultiColumnHeader)m_TreeView.multiColumnHeader).ShowMode == AH_MultiColumnHeader.AssetShowMode.Unused)
            {
                Heureka_WindowStyler.DrawCenteredImage(m_window, AH_EditorData.Instance.AchievementIcon.Icon);
                return;
            }

            doSearchBar(toolbarRect);
            doTreeView(multiColumnTreeViewRect);

            doBottomToolBar(bottomToolbarRect);
        }

        void OnProjectChanged()
        {
            buildInfoManager.ProjectDirty = true;
        }

        //Callback
        private void OnAssetDeleted()
        {
            if (EditorUtility.DisplayDialog("Delete empty folders", "Do you want to delete any empty folders?", "Yes", "No"))
            {
                deleteEmptyFolders();
            }

            //This might be called excessively
            if (AH_SettingsManager.Instance.AutoRefreshLog)
                RefreshBuildLog();
        }

        //callback
        private void onBuildInfoCreated(string path)
        {
            if (EditorUtility.DisplayDialog(
                    "New buildinfo log created",
                    "Do you want to load it into Asset Hunter",
                    "Ok", "Cancel"))
            {
                m_Initialized = false;
                buildInfoManager.SelectBuildInfo(path);
            }
        }

        void InitIfNeeded()
        {
            //We dont need to do stuff when in play mode
            if (buildInfoManager && buildInfoManager.HasSelection && !m_Initialized)
            {
                // Check if it already exists (deserialized from window layout file or scriptable object)
                if (m_TreeViewState == null)
                    m_TreeViewState = new TreeViewState();

                bool firstInit = m_MultiColumnHeaderState == null;
                var headerState = AH_TreeViewWithTreeModel.CreateDefaultMultiColumnHeaderState(multiColumnTreeViewRect.width);
                if (MultiColumnHeaderState.CanOverwriteSerializedFields(m_MultiColumnHeaderState, headerState))
                    MultiColumnHeaderState.OverwriteSerializedFields(m_MultiColumnHeaderState, headerState);
                m_MultiColumnHeaderState = headerState;

                var multiColumnHeader = new AH_MultiColumnHeader(headerState);
                if (firstInit)
                    multiColumnHeader.ResizeToFit();

                var treeModel = new TreeModel<AH_TreeviewElement>(buildInfoManager.GetTreeViewData());

                m_TreeView = new AH_TreeViewWithTreeModel(m_TreeViewState, multiColumnHeader, treeModel);

                m_SearchField = new SearchField();
                m_SearchField.downOrUpArrowKeyPressed += m_TreeView.SetFocusAndEnsureSelectedItem;

                m_Initialized = true;
                buildInfoManager.ProjectDirty = false;
            }

            //This is an (ugly) fix to make sure we dotn loose our icons due to some singleton issues after play/stop
            if (guiContentRefresh.image == null)
                initializeGUIContent();
        }

        private void deleteEmptyFolders()
        {
            checkEmptyFolder(Application.dataPath);
            AssetDatabase.Refresh();
        }

        private bool checkEmptyFolder(string dataPath)
        {
            if (dataPath.EndsWith(".git", StringComparison.InvariantCultureIgnoreCase))
                return false;

            string[] files = System.IO.Directory.GetFiles(dataPath);
            bool hasValidAsset = false;

            for (int i = 0; i < files.Length; i++)
            {
                string relativePath;
                string assetID;
                AH_Utils.GetRelativePathAndAssetID(files[i], out relativePath, out assetID);

                //This folder has a valid asset inside
                if (!string.IsNullOrEmpty(assetID))
                {
                    hasValidAsset = true;
                    break;
                }
            }

            string[] folders = System.IO.Directory.GetDirectories(dataPath);
            bool hasFolderWithContents = false;

            for (int i = 0; i < folders.Length; i++)
            {
                bool folderIsEmpty = checkEmptyFolder(folders[i]);
                if (!folderIsEmpty)
                {
                    hasFolderWithContents = true;
                }
                else
                {
                    Debug.Log("AH: Deleting empty folder " + folders[i]);
                    FileUtil.DeleteFileOrDirectory(folders[i]);
                }
            }
            return (!hasValidAsset && !hasFolderWithContents);
        }

        private void initializeGUIContent()
        {
            titleContent = new GUIContent("Asset Hunter", AH_EditorData.Instance.WindowPaneIcon.Icon);

            guiContentLoadBuildInfo = new GUIContent("Load", AH_EditorData.Instance.LoadLogIcon.Icon, "Load info from a previous build");
            guiContentSettings = new GUIContent("Settings", AH_EditorData.Instance.Settings.Icon, "Open settings");
            guiContentGenerateReferenceGraph = new GUIContent("Dependencies", AH_EditorData.Instance.RefFromIcon.Icon, "See asset dependency graph");
            guiContentDuplicates = new GUIContent("Duplicates", AH_EditorData.Instance.DuplicateIcon.Icon, "Find duplicate assets");

            //Only avaliable in 2018
#if UNITY_2018_1_OR_NEWER
            guiContentBuildReport = new GUIContent("Report", AH_EditorData.Instance.ReportIcon.Icon, "Build report overview (Build size information)");
#endif
            guiContentReadme = new GUIContent("Info", AH_EditorData.Instance.HelpIcon.Icon, "Open the readme file for all installed Heureka Games products");
            guiContentDeleteAll = new GUIContent("Clean ALL", AH_EditorData.Instance.DeleteIcon.Icon, "Delete ALL unused assets in project ({0}) Remember to manually exclude relevant assets in the settings window");
            guiContentRefresh = new GUIContent(AH_EditorData.Instance.RefreshIcon.Icon, "Refresh data");
        }

        private void doNoBuildInfoLoaded()
        {
            Heureka_WindowStyler.DrawCenteredMessage(m_window, AH_EditorData.Instance.WindowHeaderIcon.Icon, 380f, 110f, "Buildinfo not yet loaded" + Environment.NewLine + "Load existing / create new build");
        }

        private void doHeader()
        {
            Heureka_WindowStyler.DrawGlobalHeader(Heureka_WindowStyler.clr_Pink, "ASSET HUNTER PRO", VERSION);
            EditorGUILayout.BeginHorizontal();

            bool infoLoaded = (buildInfoManager != null && buildInfoManager.HasSelection);
            if (infoLoaded)
            {
                GUIContent RefreshGUIContent = new GUIContent(guiContentRefresh);
                Color origColor = GUI.color;
                if (buildInfoManager.ProjectDirty)
                {
                    GUI.color = Heureka_WindowStyler.clr_Red;
                    RefreshGUIContent.tooltip = String.Format("{0}{1}", RefreshGUIContent.tooltip, " (Project has changed which means that treeview is out of date)");
                }

                if (doSelectionButton(RefreshGUIContent))
                    RefreshBuildLog();

                GUI.color = origColor;
            }


            if (doSelectionButton(guiContentLoadBuildInfo))
                openBuildInfoSelector();

            if (doSelectionButton(guiContentGenerateReferenceGraph))
                AH_DependencyGraphWindow.Init(Docker.DockPosition.Right);
            if (doSelectionButton(guiContentDuplicates))
                AH_DuplicatesWindow.Init(Docker.DockPosition.Left);       

            //Only avaliable in 2018
#if UNITY_2018_1_OR_NEWER
            if (infoLoaded && doSelectionButton(guiContentBuildReport))
                AH_BuildReportWindow.Init();
#endif
            if (doSelectionButton(guiContentSettings))
                AH_SettingsWindow.Init(true);

            /*
#if AH_HAS_OLD_INSTALLED
            //Transfer settings to PRO
            GUIContent TransferSettingsContent = new GUIContent("Transfer Settings", "Transfer your settings from old Asset Hunter into PRO");
            if (AH_VersionUpgrader.VersionUpgraderReady && GUILayout.Button(TransferSettingsContent, GUILayout.MaxHeight(18)))
                AH_VersionUpgrader.RunUpgrade();
#endif
            */

            if (infoLoaded && m_TreeView.GetCombinedUnusedSize() > 0)
            {
                string sizeAsString = AH_Utils.GetSizeAsString(m_TreeView.GetCombinedUnusedSize());

                GUIContent instancedGUIContent = new GUIContent(guiContentDeleteAll);
                instancedGUIContent.tooltip = string.Format(instancedGUIContent.tooltip, sizeAsString);
                if (AH_SettingsManager.Instance.HideButtonText)
                    instancedGUIContent.text = null;

                GUIStyle btnStyle = "button";
                GUIStyle newStyle = new GUIStyle(btnStyle);
                newStyle.normal.textColor = Heureka_WindowStyler.clr_Pink;

                m_TreeView.DrawDeleteAllButton(instancedGUIContent, newStyle, GUILayout.MaxHeight(AH_SettingsManager.Instance.HideButtonText ? ButtonMaxHeight * 2f : ButtonMaxHeight));
            }

            GUILayout.FlexibleSpace();
            GUILayout.Space(20);

            if (m_TreeView != null)
                m_TreeView.AssetSelectionToolBarGUI();

            if (doSelectionButton(guiContentReadme))
            {
                Heureka_PackageDataManagerEditor.SelectReadme();
                if (AH_EditorData.Instance.Documentation != null)
                    AssetDatabase.OpenAsset(AH_EditorData.Instance.Documentation);
            }

            EditorGUILayout.EndHorizontal();
        }

        private void doSearchBar(Rect rect)
        {
            if (m_TreeView != null)
                m_TreeView.searchString = m_SearchField.OnGUI(rect, m_TreeView.searchString);
        }

        private void doTreeView(Rect rect)
        {
            if (m_TreeView != null)
                m_TreeView.OnGUI(rect);
        }

        private void doBottomToolBar(Rect rect)
        {
            if (m_TreeView == null)
                return;

            GUILayout.BeginArea(rect);

            using (new EditorGUILayout.HorizontalScope())
            {
                GUIStyle style = "miniButton";

                if (GUILayout.Button("Expand All", style))
                {
                    m_TreeView.ExpandAll();
                }

                if (GUILayout.Button("Collapse All", style))
                {
                    m_TreeView.CollapseAll();
                }

                GUILayout.Label("Build: " + buildInfoManager.GetSelectedBuildDate() + " (" + buildInfoManager.GetSelectedBuildTarget() + ")");
                GUILayout.FlexibleSpace();
                GUILayout.Label(buildInfoManager.TreeView != null ? AssetDatabase.GetAssetPath(buildInfoManager.TreeView) : string.Empty);
                GUILayout.FlexibleSpace();

                if (((AH_MultiColumnHeader)m_TreeView.multiColumnHeader).mode == AH_MultiColumnHeader.Mode.SortedList || !string.IsNullOrEmpty(m_TreeView.searchString))
                {
                    if (GUILayout.Button("Return to Treeview", style))
                    {
                        m_TreeView.ShowTreeMode();
                    }
                }

                GUIContent exportContent = new GUIContent("Export list", "Export all the assets in the list above to a json file");
                if (GUILayout.Button(exportContent, style))
                {
                    AH_ElementList.DumpCurrentListToFile(m_TreeView);
                }
            }
            GUILayout.EndArea();
        }

        private bool doSelectionButton(GUIContent content)
        {
            GUIContent btnContent = new GUIContent(content);
            if (AH_SettingsManager.Instance.HideButtonText)
                btnContent.text = null;

            return GUILayout.Button(btnContent, GUILayout.MaxHeight(AH_SettingsManager.Instance.HideButtonText ? ButtonMaxHeight * 2f : ButtonMaxHeight));
        }

        private void OnIgnoreListUpdatedEvent()
        {
            buildInfoManager.ProjectDirty = true;

            if (AH_SettingsManager.Instance.AutoOpenLog)
                RefreshBuildLog();
        }

        private void RefreshBuildLog()
        {
            if (buildInfoManager != null && buildInfoManager.HasSelection)
            {
                m_Initialized = false;
                buildInfoManager.RefreshBuildInfo();
            }
        }

        private void openBuildInfoSelector()
        {
            string fileSelected = EditorUtility.OpenFilePanel("", AH_SerializationHelper.GetBuildInfoFolder(), AH_SerializationHelper.BuildInfoExtension);
            if (!string.IsNullOrEmpty(fileSelected))
            {
                m_Initialized = false;
                buildInfoManager.SelectBuildInfo(fileSelected);
            }
        }

        Rect toolbarRect
        {
            get { return new Rect(UiStartPos.x, UiStartPos.y + (AH_SettingsManager.Instance.HideButtonText ? 20 : 0), position.width - (UiStartPos.x * 2), 20f); }
        }

        Rect multiColumnTreeViewRect
        {
            get { return new Rect(UiStartPos.x, UiStartPos.y + 20 + (AH_SettingsManager.Instance.HideButtonText ? 20 : 0), position.width - (UiStartPos.x * 2), position.height - 90 - (AH_SettingsManager.Instance.HideButtonText ? 20 : 0)); }
        }

        Rect assetInfoRect
        {
            get { return new Rect(UiStartPos.x, position.height - 66f, position.width - (UiStartPos.x * 2), 16f); }
        }

        Rect bottomToolbarRect
        {
            get { return new Rect(UiStartPos.x, position.height - 18, position.width - (UiStartPos.x * 2), 16f); }
        }

        public Vector2 UiStartPos
        {
            get
            {
                return uiStartPos;
            }

            set
            {
                uiStartPos = value;
            }
        }

        private void OnDestroy()
        {
            AH_TreeViewSelectionInfo.OnAssetDeleted -= m_window.OnAssetDeleted;
#if UNITY_2018_1_OR_NEWER
            EditorApplication.projectChanged -= m_window.OnProjectChanged;
#elif UNITY_5_6_OR_NEWER
            EditorApplication.projectWindowChanged -= m_window.OnProjectChanged;
#endif
        }
    }
}