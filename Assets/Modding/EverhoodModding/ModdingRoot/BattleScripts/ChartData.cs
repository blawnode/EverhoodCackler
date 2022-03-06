using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace EverhoodModding
{

    public class ChartData : MonoBehaviour
    {
        public const string notesParentName = "NOTES";
        public const string sectionsParentName = "SECTIONS";
#if UNITY_EDITOR
        [SerializeField]
        private DefaultAsset chart;
#endif
        public AudioClip song;

        public ChartNoteSectionData.Data.ChartData chartData;

#if UNITY_EDITOR
        [ContextMenu("Generate Chart Data")]
        public void GenerateData()
        {
            chartData = EverhoodBattleEditor.ChartGenerator.UpdateChart(chart);

            CreateNotesLayout();
            CreateSectionsLayout(this.transform, chartData.sections);
        }

        private List<int> GetNotesIDs()
        {
            List<int> id = new List<int>();

            for (int i = 0; i < chartData.notes.Count; i++)
            {
                int ID = chartData.notes[i].noteID;

                if (!id.Contains(ID))
                {
                    id.Add(ID);
                }
            }
            return id;
        }
        private void CreateNotesLayout()
        {
            NotesParent notesParent = GetComponentInChildren<NotesParent>();
            List<int> notesIDs = GetNotesIDs();

            if (notesParent == null)
            {

                GameObject noteParent = new GameObject(notesParentName);
                noteParent.transform.SetParent(this.transform);
                noteParent.AddComponent<NotesParent>();

                for (int i = 0; i < notesIDs.Count; i++)
                {
                    string noteName = $"Note - ID = {notesIDs[i]}";
                    int noteID = notesIDs[i];
                    Transform noteSlot = CreateNoteSlot(noteParent, noteName, noteID);
                    CreateNoteEvenHandler(noteSlot.gameObject, "Event", noteID);
                }
            }
            else
            {
                NoteSlot[] noteSlotComponents = notesParent.GetComponentsInChildren<NoteSlot>();

                for (int i = 0; i < noteSlotComponents.Length; i++)
                {
                    bool noteInUse = false;
                    int usedId = 0;
                    for (int x = 0; x < notesIDs.Count; x++)
                    {
                        if (noteSlotComponents[i].noteID == notesIDs[x])
                        {
                            noteInUse = true;
                            usedId = notesIDs[x];
                        }
                    }

                    if (!noteInUse)
                    {
                        string noteName = $"Note - ID = {noteSlotComponents[i].noteID} [Not In Use]";
                        noteSlotComponents[i].gameObject.name = noteName;
                    }
                    else
                    {
                        string noteName = $"Note - ID = {usedId}";
                        noteSlotComponents[i].gameObject.name = noteName;
                    }
                }

                for (int i = 0; i < notesIDs.Count; i++)
                {
                    bool noteExist = false;
                    for (int x = 0; x < noteSlotComponents.Length; x++)
                    {
                        if (notesIDs[i] == noteSlotComponents[x].noteID)
                        {
                            noteExist = true;
                        }
                    }

                    if (!noteExist)
                    {
                        string noteName = $"Note - ID = {notesIDs[i]}";
                        int noteID = notesIDs[i];

                        Transform noteSlot = CreateNoteSlot(notesParent.gameObject, noteName, noteID);
                        CreateNoteEvenHandler(noteSlot.gameObject, "Event", noteID);
                    }
                }
            }
        }


        public void CreateSectionsLayout(Transform parent, List<ChartNoteSectionData.Data.Section> theSections)
        {
            SectionsParent sectionsParent = parent.gameObject.GetComponentInChildren<SectionsParent>();

            if (sectionsParent == null)
            {
                GameObject sectionParent = new GameObject(sectionsParentName);
                sectionParent.transform.SetParent(parent);
                sectionParent.AddComponent<SectionsParent>();

                for (int i = 0; i < theSections.Count; i++)
                {
                    string sectionName = $"Section - {theSections[i].sectionID}";
                    GameObject sectionSlot = new GameObject(sectionName);
                    sectionSlot.transform.SetParent(sectionParent.transform);

                    SectionHolder sectionEventHandler = sectionSlot.AddComponent<SectionHolder>();
                    sectionEventHandler.sectionID = theSections[i].sectionID;
                }
            }
            else
            {
                SectionHolder[] sectionEventHandlers = sectionsParent.GetComponentsInChildren<SectionHolder>();

                for (int i = 0; i < sectionEventHandlers.Length; i++)
                {
                    bool sectionUsed = false;
                    string usedID = "";
                    for (int x = 0; x < theSections.Count; x++)
                    {
                        if (sectionEventHandlers[i].sectionID == theSections[x].sectionID)
                        {
                            sectionUsed = true;
                            usedID = theSections[x].sectionID;
                        }
                    }

                    if (!sectionUsed)
                    {
                        string sectionName = $"Section - {sectionEventHandlers[i].sectionID} [Not In Use]";
                        sectionEventHandlers[i].gameObject.name = sectionName;
                    }
                    else
                    {
                        string sectionName = $"Section - {usedID}";
                        sectionEventHandlers[i].gameObject.name = sectionName;
                    }
                }

                for (int i = 0; i < theSections.Count; i++)
                {
                    bool sectionExist = false;
                    for (int x = 0; x < sectionEventHandlers.Length; x++)
                    {
                        if (theSections[i].sectionID == sectionEventHandlers[x].sectionID)
                        {
                            sectionExist = true;
                        }
                    }

                    if (!sectionExist)
                    {
                        string sectionName = $"Section - {theSections[i].sectionID}";
                        GameObject sectionSlot = new GameObject(sectionName);
                        sectionSlot.transform.SetParent(sectionsParent.transform);
                        sectionSlot.transform.SetSiblingIndex(i);

                        SectionHolder sectionEventHandler = sectionSlot.AddComponent<SectionHolder>();
                        sectionEventHandler.sectionID = theSections[i].sectionID;
                    }
                }
            }
        }


        public Transform CreateNoteSlot(GameObject noteParent, string noteName, int noteID)
        {
            GameObject noteSlot = new GameObject(noteName);
            noteSlot.transform.SetParent(noteParent.transform);
            NoteSlot noteSlotComponent = noteSlot.AddComponent<NoteSlot>();
            noteSlotComponent.noteID = noteID;

            return noteSlot.transform;
        }
        public NoteHolder CreateNoteEvenHandler(GameObject noteParent, string noteName, int noteID)
        {
            GameObject noteEvent = new GameObject(noteName);
            noteEvent.transform.SetParent(noteParent.transform);
            NoteHolder noteEventHandler = noteEvent.AddComponent<NoteHolder>();
            noteEventHandler.noteID = noteID;

            return noteEventHandler;
        }

        public void ClearChildren()
        {
            int i = 0;

            //Array to hold all child obj
            GameObject[] allChildren = new GameObject[transform.childCount];

            //Find all child obj and store to that array
            foreach (Transform child in transform)
            {
                allChildren[i] = child.gameObject;
                i += 1;
            }

            //Now destroy them
            foreach (GameObject child in allChildren)
            {
                DestroyImmediate(child.gameObject);
            }

        }
#endif

    }
}
