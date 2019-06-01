//------------------------------------------------------------
// Author: 烟雨迷离半世殇
// Mail: 1778139321@qq.com
// Data: 2019年6月1日 10:09:09
//------------------------------------------------------------

namespace ETHotfix
{
    public class M5V5GameFactory
    {
        public static void CreateM5V5Game()
        {
            M5V5Game m5V5Game = ComponentFactory.Create<M5V5Game>();
            Game.Scene.AddComponent<M5V5GameComponent, M5V5Game>(m5V5Game);
        }
    }
}