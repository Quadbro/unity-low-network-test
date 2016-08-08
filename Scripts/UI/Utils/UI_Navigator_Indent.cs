using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.UI.Utils {

    public class UI_Navigator_Indent {
        private GameObject firstPage;
        private List<GameObject> pageQueue;

        public bool Next (GameObject next) {
            if (firstPage != null) {
                pageQueue.Add(next);
                int currIndex = pageQueue.Count - 2;
                int nextIndex = pageQueue.Count - 1;

                if (currIndex >= 0) {
                    var currPage = pageQueue[currIndex];
                    var nextPage = pageQueue[nextIndex];
                    Switch(currPage, nextPage);
                    return true;
                } else if (nextIndex == 0) {
                    var nextPage = pageQueue[nextIndex];
                    nextPage.SetActive(true);
                    return true;
                } else {
                    return false;
                }
            } else {
                return false;
            }
        }

        public bool Back () {
            int currIndex = pageQueue.Count - 1;
            int prevIndex = pageQueue.Count - 2;

            if (currIndex < 1 || prevIndex < 0) {
                return false;
            } else {
                GameObject currPage = pageQueue[currIndex];
                GameObject prevPage = pageQueue[prevIndex];
                Switch(currPage, prevPage);
                pageQueue.RemoveAt(currIndex);
                return true;
            }
        }

        public bool SetFirstPage (GameObject page) {
            pageQueue = new List<GameObject>();
            if (firstPage == null) {
                firstPage = page;
                SetPageState(page, true);
                this.pageQueue.Add(page);
                return true;
            } else {
                return false;
            }
        }

        private bool SetPageState (GameObject page, bool state) {
            if (state) {
                page.SetActive(true);
                return true;
            } else {
                page.SetActive(false);
                return false;
            }
        }

        // Page switch action (Effects, transitions, ets)
        private void Switch (GameObject from, GameObject to) {
            SetPageState(from, false);
            SetPageState(to, true);
        }
    }
}