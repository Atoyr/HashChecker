using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashChecker.Abstract
{
    class AbstractRegionViewModel : AbstractViewModel, INavigationAware
    {
        /// <summary>
        /// Regionの切り替え時、Viewを再利用するか
        /// </summary>
        /// <param name="navigationContext"></param>
        /// <returns>TrueならViewを再利用する</returns>
        public virtual bool IsNavigationTarget(NavigationContext navigationContext) => true;

        /// <summary>
        /// 画面から離れるときに実行
        /// </summary>
        /// <param name="navigationContext"></param>
        public virtual void OnNavigatedFrom(NavigationContext navigationContext) { }

        /// <summary>
        /// 画面に遷移してきたときに実行
        /// </summary>
        public virtual void OnNavigatedTo(NavigationContext navigationContext) { }
    }
}
