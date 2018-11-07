using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using CommonHelpers.Common;
using CustomPrototypes.NetStandard.Models;
using CustomPrototypes.NetStandard.Services;
using Telerik.XamarinForms.ConversationalUI;
using Xamarin.Forms;

namespace CustomPrototypes.NetStandard.ViewModels
{
    public class ChatCustomizationViewModel : ViewModelBase
    {
        private readonly RepeatBotService _botService;
        private Author _meAuthor;
        private Author _botAuthor;

        public ChatCustomizationViewModel()
        {
            MeAuthor = new Author { Name = "Me"};
            BotAuthor = new Author { Name = "Bot"};
            
            Items.CollectionChanged += Items_CollectionChanged;

            _botService = new RepeatBotService();
            _botService.AttachOnReceiveMessage(OnBotMessageReceived);

            // Simulate async data loading
            Device.StartTimer(TimeSpan.FromMilliseconds(500), () =>
            {
                //TypingParticipants.Add(BotAuthor);
                Items.Add(new SimpleChatItem { Author = BotAuthor, Text = "Hi." });
                Items.Add(new SimpleChatItem { Author = BotAuthor, Text = "How can I help you?" });
                //TypingParticipants.Clear();
                return false;
            });
        }
        
        public Author MeAuthor
        {
            get => _meAuthor;
            set => SetProperty(ref _meAuthor, value);
        }

        public Author BotAuthor
        {
            get => _botAuthor;
            set => SetProperty(ref _botAuthor, value);
        }

        public ObservableCollection<SimpleChatItem> Items { get; set; } = new ObservableCollection<SimpleChatItem>();

        public ObservableCollection<Author> TypingParticipants { get; set; } = new ObservableCollection<Author>();

        private void Items_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                if (e.NewItems[0] is SimpleChatItem chatMessage &&chatMessage.Author == MeAuthor)
                {
                    TypingParticipants.Add(BotAuthor);
                    _botService.SendToBot(chatMessage.Text);
                }
            }
        }

        private void OnBotMessageReceived(string message)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                Items.Add(new SimpleChatItem { Author = BotAuthor, Text = message });
                TypingParticipants.Clear();
            });
        }
    }
}
