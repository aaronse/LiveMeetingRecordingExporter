using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Microsoft.LiveMeeting.RecordingExporter
{
    public class Recording
    {
        private string _recordingID;
        private string _title;
        private DateTime _createTime;
        private int _duration;
        private string _owner;
        private string _name;
        private bool _registration;
        private int _size;
        private DateTime _startTime;
        private string _timezone;

        public Recording(XmlNode node)
        {
            _title = node.Attributes["title"].Value;
            _recordingID = node.Attributes["reid"].Value;
            _createTime = DateTime.Parse(node.Attributes["createTime"].Value);
            _duration = Int32.Parse(node.Attributes["duration"].Value);
            _owner = node.Attributes["owner"].Value;
            _name = node.Attributes["name"].Value;
            _registration = Boolean.Parse(node.Attributes["registration"].Value);
            _size = Int32.Parse(node.Attributes["size"].Value);
            _startTime = DateTime.Parse(node.Attributes["startTime"].Value);
            _timezone = node.Attributes["timeZone"].Value;
        }

        public Recording(string title, string recordingID)
        {
            _title = title;
            _recordingID = recordingID;
            _createTime = DateTime.MinValue;
            _duration = 0;
            _owner = "";
            _name = "";
            _registration = false;
            _size = 0;
            _startTime = DateTime.MinValue;
            _timezone = TimeZone.CurrentTimeZone.ToString();
        }

        public string RecordingID { get { return _recordingID; } }
        public string Title { get { return _title; } }
        public DateTime CreateTime { get { return _createTime; } }
        public int Duration { get { return _duration; } }
        public string Owner { get { return _owner; } }
        public string Name { get { return _name; } }
        public bool Registration { get { return _registration; } }
        public int Size { get { return _size; } }
        public DateTime StartTime { get { return _startTime; } }
        public string Timezone { get { return _timezone; } }
    }
}
