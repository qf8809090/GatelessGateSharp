﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HashLib;

namespace GatelessGateSharp
{
    class DAGCache
    {
        static int[] sDAGCacheSizes = {
            16776896, 16907456, 17039296, 17170112, 17301056, 17432512, 17563072, 
            17693888, 17824192, 17955904, 18087488, 18218176, 18349504, 18481088, 
            18611392, 18742336, 18874304, 19004224, 19135936, 19267264, 19398208, 
            19529408, 19660096, 19791424, 19922752, 20053952, 20184896, 20315968, 
            20446912, 20576576, 20709184, 20840384, 20971072, 21102272, 21233216, 
            21364544, 21494848, 21626816, 21757376, 21887552, 22019392, 22151104, 
            22281536, 22412224, 22543936, 22675264, 22806464, 22935872, 23068096, 
            23198272, 23330752, 23459008, 23592512, 23723968, 23854912, 23986112, 
            24116672, 24247616, 24378688, 24509504, 24640832, 24772544, 24903488, 
            25034432, 25165376, 25296704, 25427392, 25558592, 25690048, 25820096, 
            25951936, 26081728, 26214208, 26345024, 26476096, 26606656, 26737472, 
            26869184, 26998208, 27131584, 27262528, 27393728, 27523904, 27655744, 
            27786688, 27917888, 28049344, 28179904, 28311488, 28441792, 28573504, 
            28700864, 28835648, 28966208, 29096768, 29228608, 29359808, 29490752, 
            29621824, 29752256, 29882816, 30014912, 30144448, 30273728, 30406976, 
            30538432, 30670784, 30799936, 30932672, 31063744, 31195072, 31325248, 
            31456192, 31588288, 31719232, 31850432, 31981504, 32110784, 32243392, 
            32372672, 32505664, 32636608, 32767808, 32897344, 33029824, 33160768, 
            33289664, 33423296, 33554368, 33683648, 33816512, 33947456, 34076992, 
            34208704, 34340032, 34471744, 34600256, 34734016, 34864576, 34993984, 
            35127104, 35258176, 35386688, 35518528, 35650624, 35782336, 35910976, 
            36044608, 36175808, 36305728, 36436672, 36568384, 36699968, 36830656, 
            36961984, 37093312, 37223488, 37355072, 37486528, 37617472, 37747904, 
            37879232, 38009792, 38141888, 38272448, 38403392, 38535104, 38660672, 
            38795584, 38925632, 39059264, 39190336, 39320768, 39452096, 39581632, 
            39713984, 39844928, 39974848, 40107968, 40238144, 40367168, 40500032, 
            40631744, 40762816, 40894144, 41023552, 41155904, 41286208, 41418304, 
            41547712, 41680448, 41811904, 41942848, 42073792, 42204992, 42334912, 
            42467008, 42597824, 42729152, 42860096, 42991552, 43122368, 43253696, 
            43382848, 43515712, 43646912, 43777088, 43907648, 44039104, 44170432, 
            44302144, 44433344, 44564288, 44694976, 44825152, 44956864, 45088448, 
            45219008, 45350464, 45481024, 45612608, 45744064, 45874496, 46006208, 
            46136768, 46267712, 46399424, 46529344, 46660672, 46791488, 46923328, 
            47053504, 47185856, 47316928, 47447872, 47579072, 47710144, 47839936, 
            47971648, 48103232, 48234176, 48365248, 48496192, 48627136, 48757312, 
            48889664, 49020736, 49149248, 49283008, 49413824, 49545152, 49675712, 
            49807168, 49938368, 50069056, 50200256, 50331584, 50462656, 50593472, 
            50724032, 50853952, 50986048, 51117632, 51248576, 51379904, 51510848, 
            51641792, 51773248, 51903296, 52035136, 52164032, 52297664, 52427968, 
            52557376, 52690112, 52821952, 52952896, 53081536, 53213504, 53344576, 
            53475776, 53608384, 53738816, 53870528, 54000832, 54131776, 54263744, 
            54394688, 54525248, 54655936, 54787904, 54918592, 55049152, 55181248, 
            55312064, 55442752, 55574336, 55705024, 55836224, 55967168, 56097856, 
            56228672, 56358592, 56490176, 56621888, 56753728, 56884928, 57015488, 
            57146816, 57278272, 57409216, 57540416, 57671104, 57802432, 57933632, 
            58064576, 58195264, 58326976, 58457408, 58588864, 58720192, 58849984, 
            58981696, 59113024, 59243456, 59375552, 59506624, 59637568, 59768512, 
            59897792, 60030016, 60161984, 60293056, 60423872, 60554432, 60683968, 
            60817216, 60948032, 61079488, 61209664, 61341376, 61471936, 61602752, 
            61733696, 61865792, 61996736, 62127808, 62259136, 62389568, 62520512, 
            62651584, 62781632, 62910784, 63045056, 63176128, 63307072, 63438656, 
            63569216, 63700928, 63831616, 63960896, 64093888, 64225088, 64355392, 
            64486976, 64617664, 64748608, 64879424, 65009216, 65142464, 65273792, 
            65402816, 65535424, 65666752, 65797696, 65927744, 66060224, 66191296, 
            66321344, 66453056, 66584384, 66715328, 66846656, 66977728, 67108672, 
            67239104, 67370432, 67501888, 67631296, 67763776, 67895104, 68026304, 
            68157248, 68287936, 68419264, 68548288, 68681408, 68811968, 68942912, 
            69074624, 69205568, 69337024, 69467584, 69599168, 69729472, 69861184, 
            69989824, 70122944, 70253888, 70385344, 70515904, 70647232, 70778816, 
            70907968, 71040832, 71171648, 71303104, 71432512, 71564992, 71695168, 
            71826368, 71958464, 72089536, 72219712, 72350144, 72482624, 72613568, 
            72744512, 72875584, 73006144, 73138112, 73268672, 73400128, 73530944, 
            73662272, 73793344, 73924544, 74055104, 74185792, 74316992, 74448832, 
            74579392, 74710976, 74841664, 74972864, 75102784, 75233344, 75364544, 
            75497024, 75627584, 75759296, 75890624, 76021696, 76152256, 76283072, 
            76414144, 76545856, 76676672, 76806976, 76937792, 77070016, 77200832, 
            77331392, 77462464, 77593664, 77725376, 77856448, 77987776, 78118336, 
            78249664, 78380992, 78511424, 78642496, 78773056, 78905152, 79033664, 
            79166656, 79297472, 79429568, 79560512, 79690816, 79822784, 79953472, 
            80084672, 80214208, 80346944, 80477632, 80608576, 80740288, 80870848, 
            81002048, 81133504, 81264448, 81395648, 81525952, 81657536, 81786304, 
            81919808, 82050112, 82181312, 82311616, 82443968, 82573376, 82705984, 
            82835776, 82967744, 83096768, 83230528, 83359552, 83491264, 83622464, 
            83753536, 83886016, 84015296, 84147776, 84277184, 84409792, 84540608, 
            84672064, 84803008, 84934336, 85065152, 85193792, 85326784, 85458496, 
            85589312, 85721024, 85851968, 85982656, 86112448, 86244416, 86370112, 
            86506688, 86637632, 86769344, 86900672, 87031744, 87162304, 87293632, 
            87424576, 87555392, 87687104, 87816896, 87947968, 88079168, 88211264, 
            88341824, 88473152, 88603712, 88735424, 88862912, 88996672, 89128384, 
            89259712, 89390272, 89521984, 89652544, 89783872, 89914816, 90045376, 
            90177088, 90307904, 90438848, 90569152, 90700096, 90832832, 90963776, 
            91093696, 91223744, 91356992, 91486784, 91618496, 91749824, 91880384, 
            92012224, 92143552, 92273344, 92405696, 92536768, 92666432, 92798912, 
            92926016, 93060544, 93192128, 93322816, 93453632, 93583936, 93715136, 
            93845056, 93977792, 94109504, 94240448, 94371776, 94501184, 94632896, 
            94764224, 94895552, 95023424, 95158208, 95287744, 95420224, 95550016, 
            95681216, 95811904, 95943872, 96075328, 96203584, 96337856, 96468544, 
            96599744, 96731072, 96860992, 96992576, 97124288, 97254848, 97385536, 
            97517248, 97647808, 97779392, 97910464, 98041408, 98172608, 98303168, 
            98434496, 98565568, 98696768, 98827328, 98958784, 99089728, 99220928, 
            99352384, 99482816, 99614272, 99745472, 99876416, 100007104, 
            100138048, 100267072, 100401088, 100529984, 100662592, 100791872, 
            100925248, 101056064, 101187392, 101317952, 101449408, 101580608, 
            101711296, 101841728, 101973824, 102104896, 102235712, 102366016, 
            102498112, 102628672, 102760384, 102890432, 103021888, 103153472, 
            103284032, 103415744, 103545152, 103677248, 103808576, 103939648, 
            104070976, 104201792, 104332736, 104462528, 104594752, 104725952, 
            104854592, 104988608, 105118912, 105247808, 105381184, 105511232, 
            105643072, 105774784, 105903296, 106037056, 106167872, 106298944, 
            106429504, 106561472, 106691392, 106822592, 106954304, 107085376, 
            107216576, 107346368, 107478464, 107609792, 107739712, 107872192, 
            108003136, 108131392, 108265408, 108396224, 108527168, 108657344, 
            108789568, 108920384, 109049792, 109182272, 109312576, 109444928, 
            109572928, 109706944, 109837888, 109969088, 110099648, 110230976, 
            110362432, 110492992, 110624704, 110755264, 110886208, 111017408, 
            111148864, 111279296, 111410752, 111541952, 111673024, 111803456, 
            111933632, 112066496, 112196416, 112328512, 112457792, 112590784, 
            112715968, 112852672, 112983616, 113114944, 113244224, 113376448, 
            113505472, 113639104, 113770304, 113901376, 114031552, 114163264, 
            114294592, 114425536, 114556864, 114687424, 114818624, 114948544, 
            115080512, 115212224, 115343296, 115473472, 115605184, 115736128, 
            115867072, 115997248, 116128576, 116260288, 116391488, 116522944, 
            116652992, 116784704, 116915648, 117046208, 117178304, 117308608, 
            117440192, 117569728, 117701824, 117833024, 117964096, 118094656, 
            118225984, 118357312, 118489024, 118617536, 118749632, 118882112, 
            119012416, 119144384, 119275328, 119406016, 119537344, 119668672, 
            119798464, 119928896, 120061376, 120192832, 120321728, 120454336, 
            120584512, 120716608, 120848192, 120979136, 121109056, 121241408, 
            121372352, 121502912, 121634752, 121764416, 121895744, 122027072, 
            122157632, 122289088, 122421184, 122550592, 122682944, 122813888, 
            122945344, 123075776, 123207488, 123338048, 123468736, 123600704, 
            123731264, 123861952, 123993664, 124124608, 124256192, 124386368, 
            124518208, 124649024, 124778048, 124911296, 125041088, 125173696, 
            125303744, 125432896, 125566912, 125696576, 125829056, 125958592, 
            126090304, 126221248, 126352832, 126483776, 126615232, 126746432, 
            126876608, 127008704, 127139392, 127270336, 127401152, 127532224, 
            127663552, 127794752, 127925696, 128055232, 128188096, 128319424, 
            128449856, 128581312, 128712256, 128843584, 128973632, 129103808, 
            129236288, 129365696, 129498944, 129629888, 129760832, 129892288, 
            130023104, 130154048, 130283968, 130416448, 130547008, 130678336, 
            130807616, 130939456, 131071552, 131202112, 131331776, 131464384, 
            131594048, 131727296, 131858368, 131987392, 132120256, 132250816, 
            132382528, 132513728, 132644672, 132774976, 132905792, 133038016, 
            133168832, 133299392, 133429312, 133562048, 133692992, 133823296, 
            133954624, 134086336, 134217152, 134348608, 134479808, 134607296, 
            134741056, 134872384, 135002944, 135134144, 135265472, 135396544, 
            135527872, 135659072, 135787712, 135921472, 136052416, 136182848, 
            136313792, 136444864, 136576448, 136707904, 136837952, 136970048, 
            137099584, 137232064, 137363392, 137494208, 137625536, 137755712, 
            137887424, 138018368, 138149824, 138280256, 138411584, 138539584, 
            138672832, 138804928, 138936128, 139066688, 139196864, 139328704, 
            139460032, 139590208, 139721024, 139852864, 139984576, 140115776, 
            140245696, 140376512, 140508352, 140640064, 140769856, 140902336, 
            141032768, 141162688, 141294016, 141426496, 141556544, 141687488, 
            141819584, 141949888, 142080448, 142212544, 142342336, 142474432, 
            142606144, 142736192, 142868288, 142997824, 143129408, 143258944, 
            143392448, 143523136, 143653696, 143785024, 143916992, 144045632, 
            144177856, 144309184, 144440768, 144570688, 144701888, 144832448, 
            144965056, 145096384, 145227584, 145358656, 145489856, 145620928, 
            145751488, 145883072, 146011456, 146144704, 146275264, 146407232, 
            146538176, 146668736, 146800448, 146931392, 147062336, 147193664, 
            147324224, 147455936, 147586624, 147717056, 147848768, 147979456, 
            148110784, 148242368, 148373312, 148503232, 148635584, 148766144, 
            148897088, 149028416, 149159488, 149290688, 149420224, 149551552, 
            149683136, 149814976, 149943616, 150076352, 150208064, 150338624, 
            150470464, 150600256, 150732224, 150862784, 150993088, 151125952, 
            151254976, 151388096, 151519168, 151649728, 151778752, 151911104, 
            152042944, 152174144, 152304704, 152435648, 152567488, 152698816, 
            152828992, 152960576, 153091648, 153222976, 153353792, 153484096, 
            153616192, 153747008, 153878336, 154008256, 154139968, 154270912, 
            154402624, 154533824, 154663616, 154795712, 154926272, 155057984, 
            155188928, 155319872, 155450816, 155580608, 155712064, 155843392, 
            155971136, 156106688, 156237376, 156367424, 156499264, 156630976, 
            156761536, 156892352, 157024064, 157155008, 157284416, 157415872, 
            157545536, 157677248, 157810496, 157938112, 158071744, 158203328, 
            158334656, 158464832, 158596288, 158727616, 158858048, 158988992, 
            159121216, 159252416, 159381568, 159513152, 159645632, 159776192, 
            159906496, 160038464, 160169536, 160300352, 160430656, 160563008, 
            160693952, 160822208, 160956352, 161086784, 161217344, 161349184, 
            161480512, 161611456, 161742272, 161873216, 162002752, 162135872, 
            162266432, 162397888, 162529216, 162660032, 162790976, 162922048, 
            163052096, 163184576, 163314752, 163446592, 163577408, 163707968, 
            163839296, 163969984, 164100928, 164233024, 164364224, 164494912, 
            164625856, 164756672, 164887616, 165019072, 165150016, 165280064, 
            165412672, 165543104, 165674944, 165805888, 165936832, 166067648, 
            166198336, 166330048, 166461248, 166591552, 166722496, 166854208, 
            166985408, 167116736, 167246656, 167378368, 167508416, 167641024, 
            167771584, 167903168, 168034112, 168164032, 168295744, 168427456, 
            168557632, 168688448, 168819136, 168951616, 169082176, 169213504, 
            169344832, 169475648, 169605952, 169738048, 169866304, 169999552, 
            170131264, 170262464, 170393536, 170524352, 170655424, 170782016, 
            170917696, 171048896, 171179072, 171310784, 171439936, 171573184, 
            171702976, 171835072, 171966272, 172097216, 172228288, 172359232, 
            172489664, 172621376, 172747712, 172883264, 173014208, 173144512, 
            173275072, 173407424, 173539136, 173669696, 173800768, 173931712, 
            174063424, 174193472, 174325696, 174455744, 174586816, 174718912, 
            174849728, 174977728, 175109696, 175242688, 175374272, 175504832, 
            175636288, 175765696, 175898432, 176028992, 176159936, 176291264, 
            176422592, 176552512, 176684864, 176815424, 176946496, 177076544, 
            177209152, 177340096, 177470528, 177600704, 177731648, 177864256, 
            177994816, 178126528, 178257472, 178387648, 178518464, 178650176, 
            178781888, 178912064, 179044288, 179174848, 179305024, 179436736, 
            179568448, 179698496, 179830208, 179960512, 180092608, 180223808, 
            180354752, 180485696, 180617152, 180748096, 180877504, 181009984, 
            181139264, 181272512, 181402688, 181532608, 181663168, 181795136, 
            181926592, 182057536, 182190016, 182320192, 182451904, 182582336, 
            182713792, 182843072, 182976064, 183107264, 183237056, 183368384, 
            183494848, 183631424, 183762752, 183893824, 184024768, 184154816, 
            184286656, 184417984, 184548928, 184680128, 184810816, 184941248, 
            185072704, 185203904, 185335616, 185465408, 185596352, 185727296, 
            185859904, 185989696, 186121664, 186252992, 186383552, 186514112, 
            186645952, 186777152, 186907328, 187037504, 187170112, 187301824, 
            187429184, 187562048, 187693504, 187825472, 187957184, 188087104, 
            188218304, 188349376, 188481344, 188609728, 188743616, 188874304, 
            189005248, 189136448, 189265088, 189396544, 189528128, 189660992, 
            189791936, 189923264, 190054208, 190182848, 190315072, 190447424, 
            190577984, 190709312, 190840768, 190971328, 191102656, 191233472, 
            191364032, 191495872, 191626816, 191758016, 191888192, 192020288, 
            192148928, 192282176, 192413504, 192542528, 192674752, 192805952, 
            192937792, 193068608, 193198912, 193330496, 193462208, 193592384, 
            193723456, 193854272, 193985984, 194116672, 194247232, 194379712, 
            194508352, 194641856, 194772544, 194900672, 195035072, 195166016, 
            195296704, 195428032, 195558592, 195690304, 195818176, 195952576, 
            196083392, 196214336, 196345792, 196476736, 196607552, 196739008, 
            196869952, 197000768, 197130688, 197262784, 197394368, 197523904, 
            197656384, 197787584, 197916608, 198049472, 198180544, 198310208, 
            198442432, 198573632, 198705088, 198834368, 198967232, 199097792, 
            199228352, 199360192, 199491392, 199621696, 199751744, 199883968, 
            200014016, 200146624, 200276672, 200408128, 200540096, 200671168, 
            200801984, 200933312, 201062464, 201194944, 201326144, 201457472, 
            201588544, 201719744, 201850816, 201981632, 202111552, 202244032, 
            202374464, 202505152, 202636352, 202767808, 202898368, 203030336, 
            203159872, 203292608, 203423296, 203553472, 203685824, 203816896, 
            203947712, 204078272, 204208192, 204341056, 204472256, 204603328, 
            204733888, 204864448, 204996544, 205125568, 205258304, 205388864, 
            205517632, 205650112, 205782208, 205913536, 206044736, 206176192, 
            206307008, 206434496, 206569024, 206700224, 206831168, 206961856, 
            207093056, 207223616, 207355328, 207486784, 207616832, 207749056, 
            207879104, 208010048, 208141888, 208273216, 208404032, 208534336, 
            208666048, 208796864, 208927424, 209059264, 209189824, 209321792, 
            209451584, 209582656, 209715136, 209845568, 209976896, 210106432, 
            210239296, 210370112, 210501568, 210630976, 210763712, 210894272, 
            211024832, 211156672, 211287616, 211418176, 211549376, 211679296, 
            211812032, 211942592, 212074432, 212204864, 212334016, 212467648, 
            212597824, 212727616, 212860352, 212991424, 213120832, 213253952, 
            213385024, 213515584, 213645632, 213777728, 213909184, 214040128, 
            214170688, 214302656, 214433728, 214564544, 214695232, 214826048, 
            214956992, 215089088, 215219776, 215350592, 215482304, 215613248, 
            215743552, 215874752, 216005312, 216137024, 216267328, 216399296, 
            216530752, 216661696, 216790592, 216923968, 217054528, 217183168, 
            217316672, 217448128, 217579072, 217709504, 217838912, 217972672, 
            218102848, 218233024, 218364736, 218496832, 218627776, 218759104, 
            218888896, 219021248, 219151936, 219281728, 219413056, 219545024, 
            219675968, 219807296, 219938624, 220069312, 220200128, 220331456, 
            220461632, 220592704, 220725184, 220855744, 220987072, 221117888, 
            221249216, 221378368, 221510336, 221642048, 221772736, 221904832, 
            222031808, 222166976, 222297536, 222428992, 222559936, 222690368, 
            222820672, 222953152, 223083968, 223213376, 223345984, 223476928, 
            223608512, 223738688, 223869376, 224001472, 224132672, 224262848, 
            224394944, 224524864, 224657344, 224788288, 224919488, 225050432, 
            225181504, 225312704, 225443776, 225574592, 225704768, 225834176, 
            225966784, 226097216, 226229824, 226360384, 226491712, 226623424, 
            226754368, 226885312, 227015104, 227147456, 227278528, 227409472, 
            227539904, 227669696, 227802944, 227932352, 228065216, 228196288, 
            228326464, 228457792, 228588736, 228720064, 228850112, 228981056, 
            229113152, 229243328, 229375936, 229505344, 229636928, 229769152, 
            229894976, 230030272, 230162368, 230292416, 230424512, 230553152, 
            230684864, 230816704, 230948416, 231079616, 231210944, 231342016, 
            231472448, 231603776, 231733952, 231866176, 231996736, 232127296, 
            232259392, 232388672, 232521664, 232652608, 232782272, 232914496, 
            233043904, 233175616, 233306816, 233438528, 233569984, 233699776, 
            233830592, 233962688, 234092224, 234221888, 234353984, 234485312, 
            234618304, 234749888, 234880832, 235011776, 235142464, 235274048, 
            235403456, 235535936, 235667392, 235797568, 235928768, 236057152, 
            236190272, 236322752, 236453312, 236583616, 236715712, 236846528, 
            236976448, 237108544, 237239104, 237371072, 237501632, 237630784, 
            237764416, 237895232, 238026688, 238157632, 238286912, 238419392, 
            238548032, 238681024, 238812608, 238941632, 239075008, 239206336, 
            239335232, 239466944, 239599168, 239730496, 239861312, 239992384, 
            240122816, 240254656, 240385856, 240516928, 240647872, 240779072, 
            240909632, 241040704, 241171904, 241302848, 241433408, 241565248, 
            241696192, 241825984, 241958848, 242088256, 242220224, 242352064, 
            242481856, 242611648, 242744896, 242876224, 243005632, 243138496, 
            243268672, 243400384, 243531712, 243662656, 243793856, 243924544, 
            244054592, 244187072, 244316608, 244448704, 244580032, 244710976, 
            244841536, 244972864, 245104448, 245233984, 245365312, 245497792, 
            245628736, 245759936, 245889856, 246021056, 246152512, 246284224, 
            246415168, 246545344, 246675904, 246808384, 246939584, 247070144, 
            247199552, 247331648, 247463872, 247593536, 247726016, 247857088, 
            247987648, 248116928, 248249536, 248380736, 248512064, 248643008, 
            248773312, 248901056, 249036608, 249167552, 249298624, 249429184, 
            249560512, 249692096, 249822784, 249954112, 250085312, 250215488, 
            250345792, 250478528, 250608704, 250739264, 250870976, 251002816, 
            251133632, 251263552, 251395136, 251523904, 251657792, 251789248, 
            251919424, 252051392, 252182464, 252313408, 252444224, 252575552, 
            252706624, 252836032, 252968512, 253099712, 253227584, 253361728, 
            253493056, 253623488, 253754432, 253885504, 254017216, 254148032, 
            254279488, 254410432, 254541376, 254672576, 254803264, 254933824, 
            255065792, 255196736, 255326528, 255458752, 255589952, 255721408, 
            255851072, 255983296, 256114624, 256244416, 256374208, 256507712, 
            256636096, 256768832, 256900544, 257031616, 257162176, 257294272, 
            257424448, 257555776, 257686976, 257818432, 257949632, 258079552, 
            258211136, 258342464, 258473408, 258603712, 258734656, 258867008, 
            258996544, 259127744, 259260224, 259391296, 259522112, 259651904, 
            259784384, 259915328, 260045888, 260175424, 260308544, 260438336, 
            260570944, 260700992, 260832448, 260963776, 261092672, 261226304, 
            261356864, 261487936, 261619648, 261750592, 261879872, 262011968, 
            262143424, 262274752, 262404416, 262537024, 262667968, 262799296, 
            262928704, 263061184, 263191744, 263322944, 263454656, 263585216, 
            263716672, 263847872, 263978944, 264108608, 264241088, 264371648, 
            264501184, 264632768, 264764096, 264895936, 265024576, 265158464, 
            265287488, 265418432, 265550528, 265681216, 265813312, 265943488, 
            266075968, 266206144, 266337728, 266468032, 266600384, 266731072, 
            266862272, 266993344, 267124288, 267255616, 267386432, 267516992, 
            267648704, 267777728, 267910592, 268040512, 268172096, 268302784, 
            268435264, 268566208, 268696256, 268828096, 268959296, 269090368, 
            269221312, 269352256, 269482688, 269614784, 269745856, 269876416, 
            270007616, 270139328, 270270272, 270401216, 270531904, 270663616, 
            270791744, 270924736, 271056832, 271186112, 271317184, 271449536, 
            271580992, 271711936, 271843136, 271973056, 272105408, 272236352, 
            272367296, 272498368, 272629568, 272759488, 272891456, 273022784, 
            273153856, 273284672, 273415616, 273547072, 273677632, 273808448, 
            273937088, 274071488, 274200896, 274332992, 274463296, 274595392, 
            274726208, 274857536, 274988992, 275118656, 275250496, 275382208, 
            275513024, 275643968, 275775296, 275906368, 276037184, 276167872, 
            276297664, 276429376, 276560576, 276692672, 276822976, 276955072, 
            277085632, 277216832, 277347008, 277478848, 277609664, 277740992, 
            277868608, 278002624, 278134336, 278265536, 278395328, 278526784, 
            278657728, 278789824, 278921152, 279052096, 279182912, 279313088, 
            279443776, 279576256, 279706048, 279838528, 279969728, 280099648, 
            280230976, 280361408, 280493632, 280622528, 280755392, 280887104, 
            281018176, 281147968, 281278912, 281411392, 281542592, 281673152, 
            281803712, 281935552, 282066496, 282197312, 282329024, 282458816, 
            282590272, 282720832, 282853184, 282983744, 283115072, 283246144, 
            283377344, 283508416, 283639744, 283770304, 283901504, 284032576, 
            284163136, 284294848, 284426176, 284556992, 284687296, 284819264, 
            284950208, 285081536
        };

        public static int WORD_BYTES = 4;                   // bytes in word
        public static int DATASET_BYTES_INIT = 1073741824;  // bytes in dataset at genesis
        public static int DATASET_BYTES_GROWTH = 8388608;   // dataset growth per epoch
        public static int CACHE_BYTES_INIT = 16777216;      // bytes in cache at genesis
        public static int CACHE_BYTES_GROWTH = 131072;      // cache growth per epoch
        public static int CACHE_MULTIPLIER = 1024;          // size of the DAG relative to the cache
        public static int EPOCH_LENGTH = 30000;             // blocks per epoch
        public static int MIX_BYTES = 128;                  // width of mix
        public static int HASH_BYTES = 64;                  // hash length in bytes
        public static int DATASET_PARENTS = 256;            // number of parents of each dataset element
        public static int CACHE_ROUNDS = 3;                 // number of rounds in cache production
        public static int ACCESSES = 64;                    // number of accesses in hashimoto loop

        static Mutex mMutex = new Mutex();
        static Dictionary<int, byte[]> sDAGCacheDatabase = new Dictionary<int, byte[]>();

        int mEpoch;
        String mSeedhash;

        public DAGCache(int aEpoch, String aSeedhash)
        {
            mEpoch = aEpoch;
            mSeedhash = aSeedhash;
        }

        public byte[] Data()
        {
            IHash hash = HashFactory.Crypto.SHA3.CreateKeccak512();
            byte[] data;

            mMutex.WaitOne();
            if (sDAGCacheDatabase.ContainsKey(mEpoch))
            {
                data = sDAGCacheDatabase[mEpoch];
            }
            else
            {
                System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
                sw.Start();

                data = new byte[sDAGCacheSizes[mEpoch]];

                byte[] o = hash.ComputeBytes(Utilities.StringToByteArray(mSeedhash)).GetBytes();
                int n = data.Length / HASH_BYTES;
                Buffer.BlockCopy(o, 0, data, 0, HASH_BYTES);
                for (int i = 1; i < n; ++i)
                {
                    o = hash.ComputeBytes(o).GetBytes();
                    Buffer.BlockCopy(o, 0, data, i * HASH_BYTES, HASH_BYTES);
                }

                o = new byte[64];
                for (int k = 0; k < CACHE_ROUNDS; ++k)
                {
                    for (int i = 0; i < n; ++i)
                    {
                        int u = ((i - 1 + n) % n);
                        int v = (int)((  ((UInt32)(data[i * HASH_BYTES + 0]) << 0)
                                       | ((UInt32)(data[i * HASH_BYTES + 1]) << 8) 
                                       | ((UInt32)(data[i * HASH_BYTES + 2]) << 16) 
                                       | ((UInt32)(data[i * HASH_BYTES + 3]) << 24)) % (UInt32)n);
                        for (int j = 0; j < HASH_BYTES; ++j)
                            o[j] = (byte)(data[u * HASH_BYTES + j] ^ data[v * HASH_BYTES + j]);
                        o = hash.ComputeBytes(o).GetBytes();
                        Buffer.BlockCopy(o, 0, data, i * HASH_BYTES, HASH_BYTES);
                    }
                }

                sDAGCacheDatabase[mEpoch] = data;
                sw.Stop();

                MainForm.Logger("Generated DAG cache for Epoch #" + mEpoch + " (" + (long)sw.Elapsed.TotalMilliseconds + "ms).");
            }
            mMutex.ReleaseMutex();
            return data;
        }
    }
}
