using System;
using Xamarin.Forms;
using System.Threading;
using System.Windows.Input;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CollectionView_LoadMore {
    public class ViewModel : INotifyPropertyChanged {
        readonly MailMessageRepository repository;
        DateTime currentDate = DateTime.Now;
        readonly Random random;

        public ViewModel(MailMessageRepository repository) {
            this.random = new Random((int)DateTime.Now.Ticks);
            this.repository = repository;
            LoadMoreCommand = new Command(ExecuteLoadMoreCommand);
        }

        IList<MailData> itemSource;
        public IList<MailData> ItemSource {
            get { return itemSource; }
            set {
                if (itemSource != value) {
                    itemSource = value;
                    OnPropertyChanged("ItemSource");
                }
            }
        }

        bool isRefreshing = false;
        public bool IsRefreshing {
            get { return isRefreshing; }
            set {
                if (isRefreshing != value) {
                    isRefreshing = value;
                    OnPropertyChanged("IsRefreshing");
                }
            }
        }

        ICommand loadMoreCommand = null;
        public ICommand LoadMoreCommand {
            get { return loadMoreCommand; }
            set {
                if (loadMoreCommand != value) {
                    loadMoreCommand = value;
                    OnPropertyChanged("LoadMoreCommand");
                }
            }
        }

        void ExecuteLoadMoreCommand() {
            Task.Run(() => {
                Thread.Sleep(1000);

                if (ItemSource == null)
                    ItemSource = new List<MailData>();

                foreach (MailData mail in this.repository.MailMessages) {
                    this.currentDate = this.currentDate.AddMinutes(-1 * this.random.Next(5, 240));

                    ItemSource.Add(new MailData() {
                        SenderName = mail.SenderName,
                        SenderEmail = mail.SenderEmail,
                        Subject = mail.Subject,
                        Body = mail.Body,
                        MailTime = this.currentDate,

                    });
                }
                IsRefreshing = false;
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "") {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}