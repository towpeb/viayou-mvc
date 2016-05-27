using System.ComponentModel.DataAnnotations;

namespace ViaYou.Domain
{
    public class KeyWord
    {
        public KeyWord()
        {
            
        }
        public KeyWord(int id, string keywords, string description, string facebookMsg, byte[] facebookImg, string twitterMsg, byte[] twitterImg, bool active)
        {
            Id = id;
            Keywords = keywords;
            Description = description;
            FacebookMsg = facebookMsg;
            FacebookImg = facebookImg;
            TwitterMsg = twitterMsg;
            TwitterImg = twitterImg;
            Active = active;
        }
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Keywords { get; set; }
        [Required]
        [MaxLength(500)]
        public string Description { get; set; }
        [MaxLength(200)]
        public string FacebookMsg { get; set; }
        public byte[] FacebookImg { get; set; }
        [MaxLength(200)]
        public string TwitterMsg { get; set; }
        public byte[] TwitterImg { get; set; }
        public bool Active { get; set; }
    }
}
