
namespace BakkalAPI.Models
{
    public class NotificationModel
    {
        public string Id { get; set; }

        public string BakkalId { get; set; }

        public string BakkalName { get; set; }

        public string Description { get; set; }

        public bool IsConfirm { get; set; }

        public string Icon { get; set; }

        public string BgColor { get; set; }
    }
}