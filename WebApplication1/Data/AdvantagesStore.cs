using WebApplication1.Models.DTO;

namespace WebApplication1.Data
{
    public class AdvantagesStore
    {
        public static List<AdvantagesDTO> advantagesList = new List<AdvantagesDTO>
            {
                new AdvantagesDTO{id=1, name="Poll View", text="Jurek Ogórek kiełba i żurek" },
                new AdvantagesDTO{id=2, name="Beach View", text="Stejki Burneiki" }
            };
    }
}
