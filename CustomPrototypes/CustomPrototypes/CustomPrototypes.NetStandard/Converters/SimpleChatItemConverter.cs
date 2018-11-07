using CustomPrototypes.NetStandard.Models;
using CustomPrototypes.NetStandard.ViewModels;
using Telerik.XamarinForms.ConversationalUI;

namespace CustomPrototypes.NetStandard.Converters
{
    public class SimpleChatItemConverter : IChatItemConverter
    {
        public ChatItem ConvertToChatItem(object dataItem, ChatItemConverterContext context)
        {
            var textMessage = new TextMessage();

            if (dataItem is SimpleChatItem item)
            {
                textMessage.Data = dataItem;
                textMessage.Author = item.Author;
                textMessage.Text = item.Text;
            }

            return textMessage;
        }

        public object ConvertToDataItem(object message, ChatItemConverterContext context)
        {
            var chatItem = new SimpleChatItem();

            if (context.Chat.BindingContext is ChatCustomizationViewModel viewModel)
            {
                chatItem.Author = viewModel.MeAuthor;
                chatItem.Text = (string) message;
            }

            return chatItem;
        }
    }
}
