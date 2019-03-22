using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.Global
{
    public enum EnumJsonResult
    {
        /// <summary>
        /// 异常
        /// </summary>
        Exception = -99,
        /// <summary>
        /// 未登录
        /// </summary>
        NotLogin = -1,
        /// <summary>
        /// 没有权限
        /// </summary>
        NoAccess = -2,
        /// <summary>
        /// 验证未通过
        /// </summary>
        ModelStateError = -3,
        /// <summary>
        /// 操作成功
        /// </summary>
        OK = 1,
        /// <summary>
        /// 操作失败
        /// </summary>
        Fail = 3,
        /// <summary>
        /// 用户已注册
        /// </summary>
        AlreadyReg = 2,
        /// <summary>
        /// 用户已关联
        /// </summary>
        AlreadyAsso = 22,
        /// <summary>
        /// 已在在其他的移动端登陆
        /// </summary>
        OtherLogin = -100,
        /// <summary>
        /// 验证码已失效
        /// </summary>
        ValidateCodeFaile = -101,
        /// <summary>
        /// 验证码访问过于频繁
        /// </summary>
        ValidateCodeOften = -102,
        /// <summary>
        /// 账号格式不正确
        /// </summary>
        ErrorAccountNo = -103,
        /// <summary>
        /// 不能给自己点赞收藏自己的文章等
        /// </summary>
        NotOperateOwnThing = 4,
        /// <summary>
        /// 未查询到数据
        /// </summary>
        NoData = 5,
        /// <summary>
        /// appKey验证未通过
        /// </summary>
        NotAppKey = -4,
        /// <summary>
        /// 强制更新
        /// </summary>
        ForceUpdate = 6,
        /// <summary>
        /// 取消点赞
        /// </summary>
        CancelPraise = 7,
        /// <summary>
        /// 版本更新
        /// </summary>
        PackageUpdate = 8,

    }
}
