namespace LearnIt.DTO
{
    public class SaveUserWordsDto
    {
        public string DeviceId { get; set; }

        public long[] WordIds { get; set; }

        public SaveUserWordsDto()
        {

        }

        public SaveUserWordsDto(string deviceId, long[] wordIds)
        {
            DeviceId = deviceId;
            WordIds = wordIds;
        }
    }
}