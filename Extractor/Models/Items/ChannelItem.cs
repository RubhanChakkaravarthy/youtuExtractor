namespace Extractor.Models
{
	public class ChannelItem : Item
	{
		public string ChannelId { get; set; }
		public bool IsVerified { get; set; }
		public string SubscribersCount { get; set; }

		public override string ToString()
		{
			return $"{Name} {(IsVerified ? "\u2713" : "")}\t{SubscribersCount}\n{Url}";
		}
	}
}