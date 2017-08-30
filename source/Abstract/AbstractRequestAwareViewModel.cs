using Prism.Interactivity.InteractionRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashChecker.Abstract
{
    public class AbstractRequestAwareViewModel : AbstractViewModel, IInteractionRequestAware
    {
        public virtual INotification Notification { set; get; }
        public virtual Action FinishInteraction { set; get; }
    }
}
