namespace FL.Basecode.WebAPI.DTOs
{
    public class IconsDTO
    {
        // --- Request DTOs ---
        public class CreateRequest
        {
            public string IconName { get; set; }
            public string IconUrl { get; set; }
        }

        // Used when updating an existing icon
        public class UpdateRequest
        {
            public string IconId { get; set; } // must be provided
            public string IconName { get; set; }
            public string IconUrl { get; set; }
        }

        // --- Response DTOs ---

        // Used in responses for create, read, and update
        public class Response
        {
            public string IconId { get; set; }
            public string IconName { get; set; }
            public string IconUrl { get; set; } // decrypted URL
            public int CreatedAt { get; set; }  // epoch seconds
            public int UpdatedAt { get; set; }  // epoch seconds
        }

        // Used in delete response
        public class DeleteResponse
        {
            public string IconId { get; set; }
            public bool Success { get; set; }
            public string Message { get; set; }
        }
    }
}
