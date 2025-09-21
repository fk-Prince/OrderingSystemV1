using System.Threading.Tasks;

namespace OrderingSystem.Repository
{
    public interface ICouponRepository
    {
        Task<Model.CouponModel> getCoupon(string code);
    }
}
