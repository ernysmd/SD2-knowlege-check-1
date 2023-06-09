using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software2KnowledgeCheck1
{
    public class BuildingRepo
    {
        public List<Building> Buildings { get; } = new List<Building>();

        //public void CreateApartment(Apartment apartment)
        public void CreateBuilding<T>(Building building) where T : Building
        {
            // Get materials
            var materialRepo = new MaterialsRepo();
            var materialsNeeded = materialRepo.GetMaterials();

            var permitRepo = new ZoningAndPermitRepo();

            var constructionRepo = new ConstructionRepo();

            var buildingWasMade = constructionRepo.ConstructBuilding<T>(materialsNeeded, permitRepo.GetPermit(), permitRepo.ZoningApproves());

            if (buildingWasMade)
            {
                Buildings.Add(building);
            }
        }
    }
}
