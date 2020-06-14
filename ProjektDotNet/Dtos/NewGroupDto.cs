using System.Collections.Generic;

namespace ProjektDotNet.Dtos
{
    public class NewGroupDto
    {
        public int TrainerId { get; set; }
        public List<int> PlayerIds { get; set; }
    }
}