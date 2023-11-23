using UnityEngine;
using HardWork;

namespace HardWork
{
    public class PlayerLoadController : MonoBehaviour
    {
        private bool _isUpLoad;
        private bool _isUnload;

        public bool IsUpload => _isUpLoad;

        public bool IsUnload => _isUnload;

        public void SetUploadStatus(bool status)
        {
            _isUpLoad = status;
        }

        public void SetUnloadStatus(bool status)
        {
            _isUnload = status;
        }
    }
}