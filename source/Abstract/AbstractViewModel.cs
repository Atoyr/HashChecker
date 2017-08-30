using Microsoft.Practices.Unity;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashChecker.Abstract
{
    public abstract class AbstractViewModel : BindableBase
    {
        /// <summary>
        /// DIコンテナを取得します
        /// コンストラクタ実行後に登録するため、コンストラクタ内で設定する場合は別途コンストラクタに引数を受け取って処理してください
        /// </summary>
        [Dependency]
        public IUnityContainer Container { get; set; }

        /// <summary>
        /// DIコンテナからRegionManagerを登録します
        /// コンストラクタ実行後に登録するため、コンストラクタ内で設定する場合は別途コンストラクタに引数を受け取って処理してください
        /// </summary>
        [Dependency]
        public IRegionManager RegionManager { get; set; }

        /// <summary>
        /// DIコンテナからEventAggregatorを登録します
        /// コンストラクタ実行後に登録するため、コンストラクタ内で設定する場合は別途コンストラクタに引数を受け取って処理してください
        /// </summary>
        [Dependency]
        public IEventAggregator EventAggregator { get; set; }

        protected AbstractViewModel()
        {
            this.Initialize();
        }

        /// <summary>
        /// 初期化処理
        /// </summary>
        public virtual void Initialize() { }
    }
}
