﻿using System.ComponentModel;

namespace ClassLibraryModels.DTOs
{
    public class CategoryDTO : INotifyPropertyChanged
    {
        private bool _isSelected;
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                if (_isSelected != value)
                {
                    _isSelected = value;
                    OnPropertyChanged(nameof(IsSelected));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
