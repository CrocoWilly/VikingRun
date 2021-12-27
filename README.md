# VikingRun



# Environment
Unity2020.3

# How to Play

    按下Start Game進入主遊戲畫面，一進入主遊戲畫面就開始遊戲。
    角色會自動奔跑，連續按著W可以加速，按A人物向左移動、
    按D人物向右移動，遇到障礙物可以透過A、D的移動避開。
    碰到障礙物、坑洞時可以透過按Space跳躍來跳過它們。
    按K人物向左轉、按J人物向右轉。

# Game

    遊戲沒有終點，只要碰到障礙物或是跳入坑洞就死了。
    主遊戲畫面的左上角有生存時間和吃到的金幣數量。
    死亡後，會跳出遊玩後的遊戲結果。另外，若遊戲玩到一半
    想中斷遊戲，可以用滑鼠點擊右下角的暫停按紐。

# Bonus

1.Infinite ground spawner

2.A good game structure design (code)

    每個C# script的class只專門做一件事
      例如:sceneSwitcher只用來換scene，且每次換scene都用它。
          infiniteFloor就只做跟地板生成有關的事，不會跟coin和barrier的生成有關

3.Some special game objects which aren’t mentioned above
  
    (1)viking在跳和掉落深淵的時候會有jump的動畫
    (2)enemy在viking被抓到的時候會揍viking，看起來很有趣

4.How good my game is
  
    自由度超高，沒有牆壁的限制，人物的速度也沒有上限，
    推薦大家比較不一樣的玩法:
    邊按W邊跳躍，會感覺像在飛一樣，玩起來很不錯。
    但要小心加速過頭會掉進深淵!


# Feedback

    我覺得VikingRun這個作業難度有點高，很盡力地把所有要求都寫好，
    但其中還是有一點小bug，就像產生coin和barrier可能會漂浮在半空中，
    這點要請助教們見諒。但這個作業真的讓我對Unity的語法、很多操作
    更了解，雖然講師上課教得不少也講得很清楚，可是也有滿多東西是要
    自己額外學的。總之，在一個月之內把Unity弄熟還滿開心的，也對接下來
    的期末專題有很大的幫助，謝謝一直說自己18歲的講師和有問必答的助教們。
    
# Github

    https://github.com/CrocoWilly/VikingRun_HW