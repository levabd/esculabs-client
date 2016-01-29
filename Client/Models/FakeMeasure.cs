namespace Client.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public sealed class FakeMeasure : BaseModel
    {
        private string _source;
        private string _processed;
        private bool _correct;

        public string Source
        {
            get { return _source; }
            set
            {
                if (_source == value)
                {
                    return;
                }

                _source = value;
                OnPropertyChanged();
            }
        }

        public string Processed
        {
            get { return _processed; }
            set
            {
                if (_processed == value)
                {
                    return;
                }

                _processed = value;
                OnPropertyChanged();
            }
        }

        public bool Correct
        {
            get { return _correct; }
            set
            {
                if (_correct == value)
                {
                    return;
                }

                _correct = value;
                OnPropertyChanged();
            }
        }
    }
}
