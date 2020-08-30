using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace Personal_Website.Data.Services {
    public class BrowserResizeService {

        public static event Func<Task> OnResize;

        public BrowserResizeService(IJSRuntime jsRuntime)
        {
            jsRuntime.InvokeAsync<object>("browserResize.registerResizeCallback");
        }

        [JSInvokable]
        public static async Task OnBrowserResize()
        {
            if (OnResize != null)
            {
                await OnResize.Invoke();
            }
        }

    }
}
