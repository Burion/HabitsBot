namespace HabitsBot.TelegramCore.Models
{
    public class TextMessageModel
    {
        public TextMessageModel(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
    }
}
