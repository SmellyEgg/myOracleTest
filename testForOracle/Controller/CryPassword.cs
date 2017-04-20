using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testForOracle.Controller
{
    /// <summary>
    /// 加密工具
    /// </summary>
    public class CryPassword
    {
        private string _key = string.Empty;
        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string EnCodeStr(string str)
        {
            this.GetKey();
            string newPassword = Neusoft.HisCrypto.DESCryptoService.DESDecrypt(str, _key);
            return newPassword;
        }

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string DeCodeStr(string str)
        {
            this.GetKey();
            string newStr = Neusoft.HisCrypto.DESCryptoService.DESEncrypt(str, _key);
            return newStr;
        }

        private string GetKey()
        {
            if (string.IsNullOrEmpty(this._key))
            {
                XmlConfigController xc = new XmlConfigController();
                this._key = xc.GetKeyOfCryPd();
            }
            return _key;
        }
    }
}
