
namespace APIFun.Data
{
    public class EFFoodRepository : IFoodRepository
    {
        private FoodContext _foodContext;
        // set  up constructor
        public EFFoodRepository(FoodContext temp) {
            _foodContext = temp;
        }
        public IEnumerable<MarriottFood> Foods => _foodContext.Foods;

    }
}
