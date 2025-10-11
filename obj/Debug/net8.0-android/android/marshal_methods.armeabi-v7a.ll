; ModuleID = 'marshal_methods.armeabi-v7a.ll'
source_filename = "marshal_methods.armeabi-v7a.ll"
target datalayout = "e-m:e-p:32:32-Fi8-i64:64-v128:64:128-a:0:32-n32-S64"
target triple = "armv7-unknown-linux-android21"

%struct.MarshalMethodName = type {
	i64, ; uint64_t id
	ptr ; char* name
}

%struct.MarshalMethodsManagedClass = type {
	i32, ; uint32_t token
	ptr ; MonoClass klass
}

@assembly_image_cache = dso_local local_unnamed_addr global [327 x ptr] zeroinitializer, align 4

; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = dso_local local_unnamed_addr constant [648 x i32] [
	i32 2616222, ; 0: System.Net.NetworkInformation.dll => 0x27eb9e => 67
	i32 10166715, ; 1: System.Net.NameResolution.dll => 0x9b21bb => 66
	i32 15721112, ; 2: System.Runtime.Intrinsics.dll => 0xefe298 => 107
	i32 26230656, ; 3: Microsoft.Extensions.DependencyModel => 0x1903f80 => 182
	i32 32687329, ; 4: Xamarin.AndroidX.Lifecycle.Runtime => 0x1f2c4e1 => 243
	i32 34715100, ; 5: Xamarin.Google.Guava.ListenableFuture.dll => 0x211b5dc => 277
	i32 34839235, ; 6: System.IO.FileSystem.DriveInfo => 0x2139ac3 => 47
	i32 39485524, ; 7: System.Net.WebSockets.dll => 0x25a8054 => 79
	i32 42639949, ; 8: System.Threading.Thread => 0x28aa24d => 142
	i32 66541672, ; 9: System.Diagnostics.StackTrace => 0x3f75868 => 29
	i32 67008169, ; 10: zh-Hant\Microsoft.Maui.Controls.resources => 0x3fe76a9 => 318
	i32 68219467, ; 11: System.Security.Cryptography.Primitives => 0x410f24b => 123
	i32 72070932, ; 12: Microsoft.Maui.Graphics.dll => 0x44bb714 => 193
	i32 82292897, ; 13: System.Runtime.CompilerServices.VisualC.dll => 0x4e7b0a1 => 101
	i32 101534019, ; 14: Xamarin.AndroidX.SlidingPaneLayout => 0x60d4943 => 261
	i32 117431740, ; 15: System.Runtime.InteropServices => 0x6ffddbc => 106
	i32 120558881, ; 16: Xamarin.AndroidX.SlidingPaneLayout.dll => 0x72f9521 => 261
	i32 122350210, ; 17: System.Threading.Channels.dll => 0x74aea82 => 136
	i32 134690465, ; 18: Xamarin.Kotlin.StdLib.Jdk7.dll => 0x80736a1 => 281
	i32 142721839, ; 19: System.Net.WebHeaderCollection => 0x881c32f => 76
	i32 149972175, ; 20: System.Security.Cryptography.Primitives.dll => 0x8f064cf => 123
	i32 159306688, ; 21: System.ComponentModel.Annotations => 0x97ed3c0 => 13
	i32 165246403, ; 22: Xamarin.AndroidX.Collection.dll => 0x9d975c3 => 217
	i32 176265551, ; 23: System.ServiceProcess => 0xa81994f => 131
	i32 182336117, ; 24: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0xade3a75 => 263
	i32 184328833, ; 25: System.ValueTuple.dll => 0xafca281 => 148
	i32 195452805, ; 26: vi/Microsoft.Maui.Controls.resources.dll => 0xba65f85 => 315
	i32 199333315, ; 27: zh-HK/Microsoft.Maui.Controls.resources.dll => 0xbe195c3 => 316
	i32 205061960, ; 28: System.ComponentModel => 0xc38ff48 => 18
	i32 209399409, ; 29: Xamarin.AndroidX.Browser.dll => 0xc7b2e71 => 215
	i32 220171995, ; 30: System.Diagnostics.Debug => 0xd1f8edb => 26
	i32 230216969, ; 31: Xamarin.AndroidX.Legacy.Support.Core.Utils.dll => 0xdb8d509 => 237
	i32 230752869, ; 32: Microsoft.CSharp.dll => 0xdc10265 => 1
	i32 231409092, ; 33: System.Linq.Parallel => 0xdcb05c4 => 58
	i32 231814094, ; 34: System.Globalization => 0xdd133ce => 41
	i32 246610117, ; 35: System.Reflection.Emit.Lightweight => 0xeb2f8c5 => 90
	i32 261689757, ; 36: Xamarin.AndroidX.ConstraintLayout.dll => 0xf99119d => 220
	i32 276479776, ; 37: System.Threading.Timer.dll => 0x107abf20 => 144
	i32 278686392, ; 38: Xamarin.AndroidX.Lifecycle.LiveData.dll => 0x109c6ab8 => 239
	i32 280482487, ; 39: Xamarin.AndroidX.Interpolator => 0x10b7d2b7 => 236
	i32 280992041, ; 40: cs/Microsoft.Maui.Controls.resources.dll => 0x10bf9929 => 287
	i32 291076382, ; 41: System.IO.Pipes.AccessControl.dll => 0x1159791e => 53
	i32 298918909, ; 42: System.Net.Ping.dll => 0x11d123fd => 68
	i32 317674968, ; 43: vi\Microsoft.Maui.Controls.resources => 0x12ef55d8 => 315
	i32 318968648, ; 44: Xamarin.AndroidX.Activity.dll => 0x13031348 => 206
	i32 321597661, ; 45: System.Numerics => 0x132b30dd => 82
	i32 336156722, ; 46: ja/Microsoft.Maui.Controls.resources.dll => 0x14095832 => 300
	i32 342366114, ; 47: Xamarin.AndroidX.Lifecycle.Common => 0x146817a2 => 238
	i32 347068432, ; 48: SQLitePCLRaw.lib.e_sqlite3.android.dll => 0x14afd810 => 196
	i32 356389973, ; 49: it/Microsoft.Maui.Controls.resources.dll => 0x153e1455 => 299
	i32 360082299, ; 50: System.ServiceModel.Web => 0x15766b7b => 130
	i32 367780167, ; 51: System.IO.Pipes => 0x15ebe147 => 54
	i32 374914964, ; 52: System.Transactions.Local => 0x1658bf94 => 146
	i32 375677976, ; 53: System.Net.ServicePoint.dll => 0x16646418 => 73
	i32 379916513, ; 54: System.Threading.Thread.dll => 0x16a510e1 => 142
	i32 385762202, ; 55: System.Memory.dll => 0x16fe439a => 61
	i32 392610295, ; 56: System.Threading.ThreadPool.dll => 0x1766c1f7 => 143
	i32 395744057, ; 57: _Microsoft.Android.Resource.Designer => 0x17969339 => 323
	i32 403441872, ; 58: WindowsBase => 0x180c08d0 => 162
	i32 435591531, ; 59: sv/Microsoft.Maui.Controls.resources.dll => 0x19f6996b => 311
	i32 441335492, ; 60: Xamarin.AndroidX.ConstraintLayout.Core => 0x1a4e3ec4 => 221
	i32 442565967, ; 61: System.Collections => 0x1a61054f => 12
	i32 450948140, ; 62: Xamarin.AndroidX.Fragment.dll => 0x1ae0ec2c => 234
	i32 451504562, ; 63: System.Security.Cryptography.X509Certificates => 0x1ae969b2 => 124
	i32 456227837, ; 64: System.Web.HttpUtility.dll => 0x1b317bfd => 149
	i32 459347974, ; 65: System.Runtime.Serialization.Primitives.dll => 0x1b611806 => 112
	i32 465846621, ; 66: mscorlib => 0x1bc4415d => 163
	i32 469710990, ; 67: System.dll => 0x1bff388e => 161
	i32 476646585, ; 68: Xamarin.AndroidX.Interpolator.dll => 0x1c690cb9 => 236
	i32 486930444, ; 69: Xamarin.AndroidX.LocalBroadcastManager.dll => 0x1d05f80c => 249
	i32 498788369, ; 70: System.ObjectModel => 0x1dbae811 => 83
	i32 500358224, ; 71: id/Microsoft.Maui.Controls.resources.dll => 0x1dd2dc50 => 298
	i32 503918385, ; 72: fi/Microsoft.Maui.Controls.resources.dll => 0x1e092f31 => 292
	i32 513247710, ; 73: Microsoft.Extensions.Primitives.dll => 0x1e9789de => 187
	i32 526420162, ; 74: System.Transactions.dll => 0x1f6088c2 => 147
	i32 527452488, ; 75: Xamarin.Kotlin.StdLib.Jdk7 => 0x1f704948 => 281
	i32 530272170, ; 76: System.Linq.Queryable => 0x1f9b4faa => 59
	i32 539058512, ; 77: Microsoft.Extensions.Logging => 0x20216150 => 183
	i32 540030774, ; 78: System.IO.FileSystem.dll => 0x20303736 => 50
	i32 545304856, ; 79: System.Runtime.Extensions => 0x2080b118 => 102
	i32 546455878, ; 80: System.Runtime.Serialization.Xml => 0x20924146 => 113
	i32 549171840, ; 81: System.Globalization.Calendars => 0x20bbb280 => 39
	i32 557405415, ; 82: Jsr305Binding => 0x213954e7 => 274
	i32 569601784, ; 83: Xamarin.AndroidX.Window.Extensions.Core.Core => 0x21f36ef8 => 272
	i32 577335427, ; 84: System.Security.Cryptography.Cng => 0x22697083 => 119
	i32 592146354, ; 85: pt-BR/Microsoft.Maui.Controls.resources.dll => 0x234b6fb2 => 306
	i32 601371474, ; 86: System.IO.IsolatedStorage.dll => 0x23d83352 => 51
	i32 605376203, ; 87: System.IO.Compression.FileSystem => 0x24154ecb => 43
	i32 613668793, ; 88: System.Security.Cryptography.Algorithms => 0x2493d7b9 => 118
	i32 627609679, ; 89: Xamarin.AndroidX.CustomView => 0x2568904f => 226
	i32 627931235, ; 90: nl\Microsoft.Maui.Controls.resources => 0x256d7863 => 304
	i32 639843206, ; 91: Xamarin.AndroidX.Emoji2.ViewsHelper.dll => 0x26233b86 => 232
	i32 643868501, ; 92: System.Net => 0x2660a755 => 80
	i32 662205335, ; 93: System.Text.Encodings.Web.dll => 0x27787397 => 200
	i32 663517072, ; 94: Xamarin.AndroidX.VersionedParcelable => 0x278c7790 => 268
	i32 666292255, ; 95: Xamarin.AndroidX.Arch.Core.Common.dll => 0x27b6d01f => 213
	i32 672442732, ; 96: System.Collections.Concurrent => 0x2814a96c => 8
	i32 683518922, ; 97: System.Net.Security => 0x28bdabca => 72
	i32 688181140, ; 98: ca/Microsoft.Maui.Controls.resources.dll => 0x2904cf94 => 286
	i32 690569205, ; 99: System.Xml.Linq.dll => 0x29293ff5 => 152
	i32 691348768, ; 100: Xamarin.KotlinX.Coroutines.Android.dll => 0x29352520 => 283
	i32 693804605, ; 101: System.Windows => 0x295a9e3d => 151
	i32 699345723, ; 102: System.Reflection.Emit => 0x29af2b3b => 91
	i32 700284507, ; 103: Xamarin.Jetbrains.Annotations => 0x29bd7e5b => 278
	i32 700358131, ; 104: System.IO.Compression.ZipFile => 0x29be9df3 => 44
	i32 706645707, ; 105: ko/Microsoft.Maui.Controls.resources.dll => 0x2a1e8ecb => 301
	i32 709557578, ; 106: de/Microsoft.Maui.Controls.resources.dll => 0x2a4afd4a => 289
	i32 720511267, ; 107: Xamarin.Kotlin.StdLib.Jdk8 => 0x2af22123 => 282
	i32 722857257, ; 108: System.Runtime.Loader.dll => 0x2b15ed29 => 108
	i32 735137430, ; 109: System.Security.SecureString.dll => 0x2bd14e96 => 128
	i32 748832960, ; 110: SQLitePCLRaw.batteries_v2 => 0x2ca248c0 => 194
	i32 752232764, ; 111: System.Diagnostics.Contracts.dll => 0x2cd6293c => 25
	i32 755313932, ; 112: Xamarin.Android.Glide.Annotations.dll => 0x2d052d0c => 203
	i32 759454413, ; 113: System.Net.Requests => 0x2d445acd => 71
	i32 762598435, ; 114: System.IO.Pipes.dll => 0x2d745423 => 54
	i32 775507847, ; 115: System.IO.Compression => 0x2e394f87 => 45
	i32 777317022, ; 116: sk\Microsoft.Maui.Controls.resources => 0x2e54ea9e => 310
	i32 789151979, ; 117: Microsoft.Extensions.Options => 0x2f0980eb => 186
	i32 790371945, ; 118: Xamarin.AndroidX.CustomView.PoolingContainer.dll => 0x2f1c1e69 => 227
	i32 804715423, ; 119: System.Data.Common => 0x2ff6fb9f => 22
	i32 807930345, ; 120: Xamarin.AndroidX.Lifecycle.LiveData.Core.Ktx.dll => 0x302809e9 => 241
	i32 823281589, ; 121: System.Private.Uri.dll => 0x311247b5 => 85
	i32 830298997, ; 122: System.IO.Compression.Brotli => 0x317d5b75 => 42
	i32 832635846, ; 123: System.Xml.XPath.dll => 0x31a103c6 => 157
	i32 834051424, ; 124: System.Net.Quic => 0x31b69d60 => 70
	i32 843511501, ; 125: Xamarin.AndroidX.Print => 0x3246f6cd => 254
	i32 873119928, ; 126: Microsoft.VisualBasic => 0x340ac0b8 => 3
	i32 877678880, ; 127: System.Globalization.dll => 0x34505120 => 41
	i32 878954865, ; 128: System.Net.Http.Json => 0x3463c971 => 62
	i32 904024072, ; 129: System.ComponentModel.Primitives.dll => 0x35e25008 => 16
	i32 911108515, ; 130: System.IO.MemoryMappedFiles.dll => 0x364e69a3 => 52
	i32 926902833, ; 131: tr/Microsoft.Maui.Controls.resources.dll => 0x373f6a31 => 313
	i32 928116545, ; 132: Xamarin.Google.Guava.ListenableFuture => 0x3751ef41 => 277
	i32 952186615, ; 133: System.Runtime.InteropServices.JavaScript.dll => 0x38c136f7 => 104
	i32 956575887, ; 134: Xamarin.Kotlin.StdLib.Jdk8.dll => 0x3904308f => 282
	i32 966729478, ; 135: Xamarin.Google.Crypto.Tink.Android => 0x399f1f06 => 275
	i32 967690846, ; 136: Xamarin.AndroidX.Lifecycle.Common.dll => 0x39adca5e => 238
	i32 975236339, ; 137: System.Diagnostics.Tracing => 0x3a20ecf3 => 33
	i32 975874589, ; 138: System.Xml.XDocument => 0x3a2aaa1d => 155
	i32 986514023, ; 139: System.Private.DataContractSerialization.dll => 0x3acd0267 => 84
	i32 987214855, ; 140: System.Diagnostics.Tools => 0x3ad7b407 => 31
	i32 992768348, ; 141: System.Collections.dll => 0x3b2c715c => 12
	i32 994442037, ; 142: System.IO.FileSystem => 0x3b45fb35 => 50
	i32 1001831731, ; 143: System.IO.UnmanagedMemoryStream.dll => 0x3bb6bd33 => 55
	i32 1012816738, ; 144: Xamarin.AndroidX.SavedState.dll => 0x3c5e5b62 => 258
	i32 1019214401, ; 145: System.Drawing => 0x3cbffa41 => 35
	i32 1028951442, ; 146: Microsoft.Extensions.DependencyInjection.Abstractions => 0x3d548d92 => 181
	i32 1029334545, ; 147: da/Microsoft.Maui.Controls.resources.dll => 0x3d5a6611 => 288
	i32 1031528504, ; 148: Xamarin.Google.ErrorProne.Annotations.dll => 0x3d7be038 => 276
	i32 1035644815, ; 149: Xamarin.AndroidX.AppCompat => 0x3dbaaf8f => 211
	i32 1036536393, ; 150: System.Drawing.Primitives.dll => 0x3dc84a49 => 34
	i32 1044663988, ; 151: System.Linq.Expressions.dll => 0x3e444eb4 => 57
	i32 1052210849, ; 152: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x3eb776a1 => 245
	i32 1067306892, ; 153: GoogleGson => 0x3f9dcf8c => 170
	i32 1082857460, ; 154: System.ComponentModel.TypeConverter => 0x408b17f4 => 17
	i32 1084122840, ; 155: Xamarin.Kotlin.StdLib => 0x409e66d8 => 279
	i32 1098259244, ; 156: System => 0x41761b2c => 161
	i32 1118262833, ; 157: ko\Microsoft.Maui.Controls.resources => 0x42a75631 => 301
	i32 1121599056, ; 158: Xamarin.AndroidX.Lifecycle.Runtime.Ktx.dll => 0x42da3e50 => 244
	i32 1127624469, ; 159: Microsoft.Extensions.Logging.Debug => 0x43362f15 => 185
	i32 1149092582, ; 160: Xamarin.AndroidX.Window => 0x447dc2e6 => 271
	i32 1157931901, ; 161: Microsoft.EntityFrameworkCore.Abstractions => 0x4504a37d => 173
	i32 1168523401, ; 162: pt\Microsoft.Maui.Controls.resources => 0x45a64089 => 307
	i32 1170634674, ; 163: System.Web.dll => 0x45c677b2 => 150
	i32 1175144683, ; 164: Xamarin.AndroidX.VectorDrawable.Animated => 0x460b48eb => 267
	i32 1178241025, ; 165: Xamarin.AndroidX.Navigation.Runtime.dll => 0x463a8801 => 252
	i32 1202000627, ; 166: Microsoft.EntityFrameworkCore.Abstractions.dll => 0x47a512f3 => 173
	i32 1203215381, ; 167: pl/Microsoft.Maui.Controls.resources.dll => 0x47b79c15 => 305
	i32 1204270330, ; 168: Xamarin.AndroidX.Arch.Core.Common => 0x47c7b4fa => 213
	i32 1204575371, ; 169: Microsoft.Extensions.Caching.Memory.dll => 0x47cc5c8b => 177
	i32 1208641965, ; 170: System.Diagnostics.Process => 0x480a69ad => 28
	i32 1219128291, ; 171: System.IO.IsolatedStorage => 0x48aa6be3 => 51
	i32 1234928153, ; 172: nb/Microsoft.Maui.Controls.resources.dll => 0x499b8219 => 303
	i32 1243150071, ; 173: Xamarin.AndroidX.Window.Extensions.Core.Core.dll => 0x4a18f6f7 => 272
	i32 1253011324, ; 174: Microsoft.Win32.Registry => 0x4aaf6f7c => 5
	i32 1260983243, ; 175: cs\Microsoft.Maui.Controls.resources => 0x4b2913cb => 287
	i32 1264511973, ; 176: Xamarin.AndroidX.Startup.StartupRuntime.dll => 0x4b5eebe5 => 262
	i32 1267360935, ; 177: Xamarin.AndroidX.VectorDrawable => 0x4b8a64a7 => 266
	i32 1273260888, ; 178: Xamarin.AndroidX.Collection.Ktx => 0x4be46b58 => 218
	i32 1275534314, ; 179: Xamarin.KotlinX.Coroutines.Android => 0x4c071bea => 283
	i32 1278448581, ; 180: Xamarin.AndroidX.Annotation.Jvm => 0x4c3393c5 => 210
	i32 1292207520, ; 181: SQLitePCLRaw.core.dll => 0x4d0585a0 => 195
	i32 1293217323, ; 182: Xamarin.AndroidX.DrawerLayout.dll => 0x4d14ee2b => 229
	i32 1309188875, ; 183: System.Private.DataContractSerialization => 0x4e08a30b => 84
	i32 1319370378, ; 184: Social Sport Hub.dll => 0x4ea3fe8a => 0
	i32 1322716291, ; 185: Xamarin.AndroidX.Window.dll => 0x4ed70c83 => 271
	i32 1324164729, ; 186: System.Linq => 0x4eed2679 => 60
	i32 1335329327, ; 187: System.Runtime.Serialization.Json.dll => 0x4f97822f => 111
	i32 1364015309, ; 188: System.IO => 0x514d38cd => 56
	i32 1373134921, ; 189: zh-Hans\Microsoft.Maui.Controls.resources => 0x51d86049 => 317
	i32 1376866003, ; 190: Xamarin.AndroidX.SavedState => 0x52114ed3 => 258
	i32 1379779777, ; 191: System.Resources.ResourceManager => 0x523dc4c1 => 98
	i32 1402170036, ; 192: System.Configuration.dll => 0x53936ab4 => 19
	i32 1406073936, ; 193: Xamarin.AndroidX.CoordinatorLayout => 0x53cefc50 => 222
	i32 1408764838, ; 194: System.Runtime.Serialization.Formatters.dll => 0x53f80ba6 => 110
	i32 1411638395, ; 195: System.Runtime.CompilerServices.Unsafe => 0x5423e47b => 100
	i32 1422545099, ; 196: System.Runtime.CompilerServices.VisualC => 0x54ca50cb => 101
	i32 1430672901, ; 197: ar\Microsoft.Maui.Controls.resources => 0x55465605 => 285
	i32 1434145427, ; 198: System.Runtime.Handles => 0x557b5293 => 103
	i32 1435222561, ; 199: Xamarin.Google.Crypto.Tink.Android.dll => 0x558bc221 => 275
	i32 1439761251, ; 200: System.Net.Quic.dll => 0x55d10363 => 70
	i32 1452070440, ; 201: System.Formats.Asn1.dll => 0x568cd628 => 37
	i32 1453312822, ; 202: System.Diagnostics.Tools.dll => 0x569fcb36 => 31
	i32 1457743152, ; 203: System.Runtime.Extensions.dll => 0x56e36530 => 102
	i32 1458022317, ; 204: System.Net.Security.dll => 0x56e7a7ad => 72
	i32 1461004990, ; 205: es\Microsoft.Maui.Controls.resources => 0x57152abe => 291
	i32 1461234159, ; 206: System.Collections.Immutable.dll => 0x5718a9ef => 9
	i32 1461719063, ; 207: System.Security.Cryptography.OpenSsl => 0x57201017 => 122
	i32 1462112819, ; 208: System.IO.Compression.dll => 0x57261233 => 45
	i32 1469204771, ; 209: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x57924923 => 212
	i32 1470490898, ; 210: Microsoft.Extensions.Primitives => 0x57a5e912 => 187
	i32 1479771757, ; 211: System.Collections.Immutable => 0x5833866d => 9
	i32 1480492111, ; 212: System.IO.Compression.Brotli.dll => 0x583e844f => 42
	i32 1487239319, ; 213: Microsoft.Win32.Primitives => 0x58a57897 => 4
	i32 1490025113, ; 214: Xamarin.AndroidX.SavedState.SavedState.Ktx.dll => 0x58cffa99 => 259
	i32 1490351284, ; 215: Microsoft.Data.Sqlite.dll => 0x58d4f4b4 => 171
	i32 1493001747, ; 216: hi/Microsoft.Maui.Controls.resources.dll => 0x58fd6613 => 295
	i32 1514721132, ; 217: el/Microsoft.Maui.Controls.resources.dll => 0x5a48cf6c => 290
	i32 1536373174, ; 218: System.Diagnostics.TextWriterTraceListener => 0x5b9331b6 => 30
	i32 1543031311, ; 219: System.Text.RegularExpressions.dll => 0x5bf8ca0f => 135
	i32 1543355203, ; 220: System.Reflection.Emit.dll => 0x5bfdbb43 => 91
	i32 1550322496, ; 221: System.Reflection.Extensions.dll => 0x5c680b40 => 92
	i32 1551623176, ; 222: sk/Microsoft.Maui.Controls.resources.dll => 0x5c7be408 => 310
	i32 1565862583, ; 223: System.IO.FileSystem.Primitives => 0x5d552ab7 => 48
	i32 1566207040, ; 224: System.Threading.Tasks.Dataflow.dll => 0x5d5a6c40 => 138
	i32 1573704789, ; 225: System.Runtime.Serialization.Json => 0x5dccd455 => 111
	i32 1580037396, ; 226: System.Threading.Overlapped => 0x5e2d7514 => 137
	i32 1582372066, ; 227: Xamarin.AndroidX.DocumentFile.dll => 0x5e5114e2 => 228
	i32 1592978981, ; 228: System.Runtime.Serialization.dll => 0x5ef2ee25 => 114
	i32 1597949149, ; 229: Xamarin.Google.ErrorProne.Annotations => 0x5f3ec4dd => 276
	i32 1601112923, ; 230: System.Xml.Serialization => 0x5f6f0b5b => 154
	i32 1603525486, ; 231: Microsoft.Maui.Controls.HotReload.Forms.dll => 0x5f93db6e => 319
	i32 1604827217, ; 232: System.Net.WebClient => 0x5fa7b851 => 75
	i32 1618516317, ; 233: System.Net.WebSockets.Client.dll => 0x6078995d => 78
	i32 1622152042, ; 234: Xamarin.AndroidX.Loader.dll => 0x60b0136a => 248
	i32 1622358360, ; 235: System.Dynamic.Runtime => 0x60b33958 => 36
	i32 1624863272, ; 236: Xamarin.AndroidX.ViewPager2 => 0x60d97228 => 270
	i32 1635184631, ; 237: Xamarin.AndroidX.Emoji2.ViewsHelper => 0x6176eff7 => 232
	i32 1636350590, ; 238: Xamarin.AndroidX.CursorAdapter => 0x6188ba7e => 225
	i32 1639515021, ; 239: System.Net.Http.dll => 0x61b9038d => 63
	i32 1639986890, ; 240: System.Text.RegularExpressions => 0x61c036ca => 135
	i32 1641389582, ; 241: System.ComponentModel.EventBasedAsync.dll => 0x61d59e0e => 15
	i32 1657153582, ; 242: System.Runtime => 0x62c6282e => 115
	i32 1658241508, ; 243: Xamarin.AndroidX.Tracing.Tracing.dll => 0x62d6c1e4 => 264
	i32 1658251792, ; 244: Xamarin.Google.Android.Material.dll => 0x62d6ea10 => 273
	i32 1670060433, ; 245: Xamarin.AndroidX.ConstraintLayout => 0x638b1991 => 220
	i32 1675553242, ; 246: System.IO.FileSystem.DriveInfo.dll => 0x63dee9da => 47
	i32 1677501392, ; 247: System.Net.Primitives.dll => 0x63fca3d0 => 69
	i32 1678508291, ; 248: System.Net.WebSockets => 0x640c0103 => 79
	i32 1679769178, ; 249: System.Security.Cryptography => 0x641f3e5a => 125
	i32 1688112883, ; 250: Microsoft.Data.Sqlite => 0x649e8ef3 => 171
	i32 1689493916, ; 251: Microsoft.EntityFrameworkCore.dll => 0x64b3a19c => 172
	i32 1691477237, ; 252: System.Reflection.Metadata => 0x64d1e4f5 => 93
	i32 1696967625, ; 253: System.Security.Cryptography.Csp => 0x6525abc9 => 120
	i32 1698840827, ; 254: Xamarin.Kotlin.StdLib.Common => 0x654240fb => 280
	i32 1701541528, ; 255: System.Diagnostics.Debug.dll => 0x656b7698 => 26
	i32 1711441057, ; 256: SQLitePCLRaw.lib.e_sqlite3.android => 0x660284a1 => 196
	i32 1720223769, ; 257: Xamarin.AndroidX.Lifecycle.LiveData.Core.Ktx => 0x66888819 => 241
	i32 1726116996, ; 258: System.Reflection.dll => 0x66e27484 => 96
	i32 1728033016, ; 259: System.Diagnostics.FileVersionInfo.dll => 0x66ffb0f8 => 27
	i32 1729485958, ; 260: Xamarin.AndroidX.CardView.dll => 0x6715dc86 => 216
	i32 1736233607, ; 261: ro/Microsoft.Maui.Controls.resources.dll => 0x677cd287 => 308
	i32 1743415430, ; 262: ca\Microsoft.Maui.Controls.resources => 0x67ea6886 => 286
	i32 1744735666, ; 263: System.Transactions.Local.dll => 0x67fe8db2 => 146
	i32 1746115085, ; 264: System.IO.Pipelines.dll => 0x68139a0d => 199
	i32 1746316138, ; 265: Mono.Android.Export => 0x6816ab6a => 166
	i32 1750313021, ; 266: Microsoft.Win32.Primitives.dll => 0x6853a83d => 4
	i32 1751397307, ; 267: Social Sport Hub => 0x686433bb => 0
	i32 1758240030, ; 268: System.Resources.Reader.dll => 0x68cc9d1e => 97
	i32 1763938596, ; 269: System.Diagnostics.TraceSource.dll => 0x69239124 => 32
	i32 1765942094, ; 270: System.Reflection.Extensions => 0x6942234e => 92
	i32 1766324549, ; 271: Xamarin.AndroidX.SwipeRefreshLayout => 0x6947f945 => 263
	i32 1770582343, ; 272: Microsoft.Extensions.Logging.dll => 0x6988f147 => 183
	i32 1776026572, ; 273: System.Core.dll => 0x69dc03cc => 21
	i32 1777075843, ; 274: System.Globalization.Extensions.dll => 0x69ec0683 => 40
	i32 1780572499, ; 275: Mono.Android.Runtime.dll => 0x6a216153 => 167
	i32 1782862114, ; 276: ms\Microsoft.Maui.Controls.resources => 0x6a445122 => 302
	i32 1788241197, ; 277: Xamarin.AndroidX.Fragment => 0x6a96652d => 234
	i32 1793755602, ; 278: he\Microsoft.Maui.Controls.resources => 0x6aea89d2 => 294
	i32 1808609942, ; 279: Xamarin.AndroidX.Loader => 0x6bcd3296 => 248
	i32 1813058853, ; 280: Xamarin.Kotlin.StdLib.dll => 0x6c111525 => 279
	i32 1813201214, ; 281: Xamarin.Google.Android.Material => 0x6c13413e => 273
	i32 1818569960, ; 282: Xamarin.AndroidX.Navigation.UI.dll => 0x6c652ce8 => 253
	i32 1818787751, ; 283: Microsoft.VisualBasic.Core => 0x6c687fa7 => 2
	i32 1824175904, ; 284: System.Text.Encoding.Extensions => 0x6cbab720 => 133
	i32 1824722060, ; 285: System.Runtime.Serialization.Formatters => 0x6cc30c8c => 110
	i32 1827303595, ; 286: Microsoft.VisualStudio.DesignTools.TapContract => 0x6cea70ab => 321
	i32 1828688058, ; 287: Microsoft.Extensions.Logging.Abstractions.dll => 0x6cff90ba => 184
	i32 1842015223, ; 288: uk/Microsoft.Maui.Controls.resources.dll => 0x6dcaebf7 => 314
	i32 1847515442, ; 289: Xamarin.Android.Glide.Annotations => 0x6e1ed932 => 203
	i32 1853025655, ; 290: sv\Microsoft.Maui.Controls.resources => 0x6e72ed77 => 311
	i32 1858542181, ; 291: System.Linq.Expressions => 0x6ec71a65 => 57
	i32 1870277092, ; 292: System.Reflection.Primitives => 0x6f7a29e4 => 94
	i32 1875935024, ; 293: fr\Microsoft.Maui.Controls.resources => 0x6fd07f30 => 293
	i32 1879696579, ; 294: System.Formats.Tar.dll => 0x7009e4c3 => 38
	i32 1885316902, ; 295: Xamarin.AndroidX.Arch.Core.Runtime.dll => 0x705fa726 => 214
	i32 1885918049, ; 296: Microsoft.VisualStudio.DesignTools.TapContract.dll => 0x7068d361 => 321
	i32 1886040351, ; 297: Microsoft.EntityFrameworkCore.Sqlite.dll => 0x706ab11f => 175
	i32 1888955245, ; 298: System.Diagnostics.Contracts => 0x70972b6d => 25
	i32 1889954781, ; 299: System.Reflection.Metadata.dll => 0x70a66bdd => 93
	i32 1898237753, ; 300: System.Reflection.DispatchProxy => 0x7124cf39 => 88
	i32 1900610850, ; 301: System.Resources.ResourceManager.dll => 0x71490522 => 98
	i32 1910275211, ; 302: System.Collections.NonGeneric.dll => 0x71dc7c8b => 10
	i32 1939592360, ; 303: System.Private.Xml.Linq => 0x739bd4a8 => 86
	i32 1956758971, ; 304: System.Resources.Writer => 0x74a1c5bb => 99
	i32 1961813231, ; 305: Xamarin.AndroidX.Security.SecurityCrypto.dll => 0x74eee4ef => 260
	i32 1968388702, ; 306: Microsoft.Extensions.Configuration.dll => 0x75533a5e => 178
	i32 1983156543, ; 307: Xamarin.Kotlin.StdLib.Common.dll => 0x7634913f => 280
	i32 1985761444, ; 308: Xamarin.Android.Glide.GifDecoder => 0x765c50a4 => 205
	i32 2003115576, ; 309: el\Microsoft.Maui.Controls.resources => 0x77651e38 => 290
	i32 2011961780, ; 310: System.Buffers.dll => 0x77ec19b4 => 7
	i32 2014489277, ; 311: Microsoft.EntityFrameworkCore.Sqlite => 0x7812aabd => 175
	i32 2019465201, ; 312: Xamarin.AndroidX.Lifecycle.ViewModel => 0x785e97f1 => 245
	i32 2025202353, ; 313: ar/Microsoft.Maui.Controls.resources.dll => 0x78b622b1 => 285
	i32 2031763787, ; 314: Xamarin.Android.Glide => 0x791a414b => 202
	i32 2045470958, ; 315: System.Private.Xml => 0x79eb68ee => 87
	i32 2055257422, ; 316: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x7a80bd4e => 240
	i32 2060060697, ; 317: System.Windows.dll => 0x7aca0819 => 151
	i32 2066184531, ; 318: de\Microsoft.Maui.Controls.resources => 0x7b277953 => 289
	i32 2070888862, ; 319: System.Diagnostics.TraceSource => 0x7b6f419e => 32
	i32 2079903147, ; 320: System.Runtime.dll => 0x7bf8cdab => 115
	i32 2090596640, ; 321: System.Numerics.Vectors => 0x7c9bf920 => 81
	i32 2103459038, ; 322: SQLitePCLRaw.provider.e_sqlite3.dll => 0x7d603cde => 197
	i32 2117912485, ; 323: Microsoft.VisualStudio.DesignTools.XamlTapContract.dll => 0x7e3cc7a5 => 322
	i32 2127167465, ; 324: System.Console => 0x7ec9ffe9 => 20
	i32 2142473426, ; 325: System.Collections.Specialized => 0x7fb38cd2 => 11
	i32 2143790110, ; 326: System.Xml.XmlSerializer.dll => 0x7fc7a41e => 159
	i32 2146852085, ; 327: Microsoft.VisualBasic.dll => 0x7ff65cf5 => 3
	i32 2159891885, ; 328: Microsoft.Maui => 0x80bd55ad => 191
	i32 2169148018, ; 329: hu\Microsoft.Maui.Controls.resources => 0x814a9272 => 297
	i32 2181898931, ; 330: Microsoft.Extensions.Options.dll => 0x820d22b3 => 186
	i32 2192057212, ; 331: Microsoft.Extensions.Logging.Abstractions => 0x82a8237c => 184
	i32 2193016926, ; 332: System.ObjectModel.dll => 0x82b6c85e => 83
	i32 2197979891, ; 333: Microsoft.Extensions.DependencyModel.dll => 0x830282f3 => 182
	i32 2201107256, ; 334: Xamarin.KotlinX.Coroutines.Core.Jvm.dll => 0x83323b38 => 284
	i32 2201231467, ; 335: System.Net.Http => 0x8334206b => 63
	i32 2207618523, ; 336: it\Microsoft.Maui.Controls.resources => 0x839595db => 299
	i32 2217644978, ; 337: Xamarin.AndroidX.VectorDrawable.Animated.dll => 0x842e93b2 => 267
	i32 2222056684, ; 338: System.Threading.Tasks.Parallel => 0x8471e4ec => 140
	i32 2244775296, ; 339: Xamarin.AndroidX.LocalBroadcastManager => 0x85cc8d80 => 249
	i32 2252106437, ; 340: System.Xml.Serialization.dll => 0x863c6ac5 => 154
	i32 2252897993, ; 341: Microsoft.EntityFrameworkCore => 0x86487ec9 => 172
	i32 2256313426, ; 342: System.Globalization.Extensions => 0x867c9c52 => 40
	i32 2265110946, ; 343: System.Security.AccessControl.dll => 0x8702d9a2 => 116
	i32 2266799131, ; 344: Microsoft.Extensions.Configuration.Abstractions => 0x871c9c1b => 179
	i32 2267999099, ; 345: Xamarin.Android.Glide.DiskLruCache.dll => 0x872eeb7b => 204
	i32 2270573516, ; 346: fr/Microsoft.Maui.Controls.resources.dll => 0x875633cc => 293
	i32 2279755925, ; 347: Xamarin.AndroidX.RecyclerView.dll => 0x87e25095 => 256
	i32 2293034957, ; 348: System.ServiceModel.Web.dll => 0x88acefcd => 130
	i32 2295906218, ; 349: System.Net.Sockets => 0x88d8bfaa => 74
	i32 2298471582, ; 350: System.Net.Mail => 0x88ffe49e => 65
	i32 2303942373, ; 351: nb\Microsoft.Maui.Controls.resources => 0x89535ee5 => 303
	i32 2305521784, ; 352: System.Private.CoreLib.dll => 0x896b7878 => 169
	i32 2315684594, ; 353: Xamarin.AndroidX.Annotation.dll => 0x8a068af2 => 208
	i32 2320631194, ; 354: System.Threading.Tasks.Parallel.dll => 0x8a52059a => 140
	i32 2340441535, ; 355: System.Runtime.InteropServices.RuntimeInformation.dll => 0x8b804dbf => 105
	i32 2344264397, ; 356: System.ValueTuple => 0x8bbaa2cd => 148
	i32 2353062107, ; 357: System.Net.Primitives => 0x8c40e0db => 69
	i32 2368005991, ; 358: System.Xml.ReaderWriter.dll => 0x8d24e767 => 153
	i32 2371007202, ; 359: Microsoft.Extensions.Configuration => 0x8d52b2e2 => 178
	i32 2378619854, ; 360: System.Security.Cryptography.Csp.dll => 0x8dc6dbce => 120
	i32 2383496789, ; 361: System.Security.Principal.Windows.dll => 0x8e114655 => 126
	i32 2395872292, ; 362: id\Microsoft.Maui.Controls.resources => 0x8ece1c24 => 298
	i32 2401565422, ; 363: System.Web.HttpUtility => 0x8f24faee => 149
	i32 2403452196, ; 364: Xamarin.AndroidX.Emoji2.dll => 0x8f41c524 => 231
	i32 2409983638, ; 365: Microsoft.VisualStudio.DesignTools.MobileTapContracts.dll => 0x8fa56e96 => 320
	i32 2421380589, ; 366: System.Threading.Tasks.Dataflow => 0x905355ed => 138
	i32 2423080555, ; 367: Xamarin.AndroidX.Collection.Ktx.dll => 0x906d466b => 218
	i32 2427813419, ; 368: hi\Microsoft.Maui.Controls.resources => 0x90b57e2b => 295
	i32 2435356389, ; 369: System.Console.dll => 0x912896e5 => 20
	i32 2435904999, ; 370: System.ComponentModel.DataAnnotations.dll => 0x9130f5e7 => 14
	i32 2454642406, ; 371: System.Text.Encoding.dll => 0x924edee6 => 134
	i32 2458678730, ; 372: System.Net.Sockets.dll => 0x928c75ca => 74
	i32 2459001652, ; 373: System.Linq.Parallel.dll => 0x92916334 => 58
	i32 2465273461, ; 374: SQLitePCLRaw.batteries_v2.dll => 0x92f11675 => 194
	i32 2465532216, ; 375: Xamarin.AndroidX.ConstraintLayout.Core.dll => 0x92f50938 => 221
	i32 2471841756, ; 376: netstandard.dll => 0x93554fdc => 164
	i32 2475788418, ; 377: Java.Interop.dll => 0x93918882 => 165
	i32 2480646305, ; 378: Microsoft.Maui.Controls => 0x93dba8a1 => 189
	i32 2483903535, ; 379: System.ComponentModel.EventBasedAsync => 0x940d5c2f => 15
	i32 2484371297, ; 380: System.Net.ServicePoint => 0x94147f61 => 73
	i32 2490993605, ; 381: System.AppContext.dll => 0x94798bc5 => 6
	i32 2501346920, ; 382: System.Data.DataSetExtensions => 0x95178668 => 23
	i32 2505896520, ; 383: Xamarin.AndroidX.Lifecycle.Runtime.dll => 0x955cf248 => 243
	i32 2522472828, ; 384: Xamarin.Android.Glide.dll => 0x9659e17c => 202
	i32 2538310050, ; 385: System.Reflection.Emit.Lightweight.dll => 0x974b89a2 => 90
	i32 2550873716, ; 386: hr\Microsoft.Maui.Controls.resources => 0x980b3e74 => 296
	i32 2562349572, ; 387: Microsoft.CSharp => 0x98ba5a04 => 1
	i32 2570120770, ; 388: System.Text.Encodings.Web => 0x9930ee42 => 200
	i32 2581783588, ; 389: Xamarin.AndroidX.Lifecycle.Runtime.Ktx => 0x99e2e424 => 244
	i32 2581819634, ; 390: Xamarin.AndroidX.VectorDrawable.dll => 0x99e370f2 => 266
	i32 2585220780, ; 391: System.Text.Encoding.Extensions.dll => 0x9a1756ac => 133
	i32 2585805581, ; 392: System.Net.Ping => 0x9a20430d => 68
	i32 2589602615, ; 393: System.Threading.ThreadPool => 0x9a5a3337 => 143
	i32 2593496499, ; 394: pl\Microsoft.Maui.Controls.resources => 0x9a959db3 => 305
	i32 2605712449, ; 395: Xamarin.KotlinX.Coroutines.Core.Jvm => 0x9b500441 => 284
	i32 2615233544, ; 396: Xamarin.AndroidX.Fragment.Ktx => 0x9be14c08 => 235
	i32 2616218305, ; 397: Microsoft.Extensions.Logging.Debug.dll => 0x9bf052c1 => 185
	i32 2617129537, ; 398: System.Private.Xml.dll => 0x9bfe3a41 => 87
	i32 2618712057, ; 399: System.Reflection.TypeExtensions.dll => 0x9c165ff9 => 95
	i32 2620871830, ; 400: Xamarin.AndroidX.CursorAdapter.dll => 0x9c375496 => 225
	i32 2624644809, ; 401: Xamarin.AndroidX.DynamicAnimation => 0x9c70e6c9 => 230
	i32 2626831493, ; 402: ja\Microsoft.Maui.Controls.resources => 0x9c924485 => 300
	i32 2627185994, ; 403: System.Diagnostics.TextWriterTraceListener.dll => 0x9c97ad4a => 30
	i32 2629843544, ; 404: System.IO.Compression.ZipFile.dll => 0x9cc03a58 => 44
	i32 2633051222, ; 405: Xamarin.AndroidX.Lifecycle.LiveData => 0x9cf12c56 => 239
	i32 2634653062, ; 406: Microsoft.EntityFrameworkCore.Relational.dll => 0x9d099d86 => 174
	i32 2663391936, ; 407: Xamarin.Android.Glide.DiskLruCache => 0x9ec022c0 => 204
	i32 2663698177, ; 408: System.Runtime.Loader => 0x9ec4cf01 => 108
	i32 2664396074, ; 409: System.Xml.XDocument.dll => 0x9ecf752a => 155
	i32 2665622720, ; 410: System.Drawing.Primitives => 0x9ee22cc0 => 34
	i32 2676780864, ; 411: System.Data.Common.dll => 0x9f8c6f40 => 22
	i32 2686887180, ; 412: System.Runtime.Serialization.Xml.dll => 0xa026a50c => 113
	i32 2693849962, ; 413: System.IO.dll => 0xa090e36a => 56
	i32 2701096212, ; 414: Xamarin.AndroidX.Tracing.Tracing => 0xa0ff7514 => 264
	i32 2715334215, ; 415: System.Threading.Tasks.dll => 0xa1d8b647 => 141
	i32 2717744543, ; 416: System.Security.Claims => 0xa1fd7d9f => 117
	i32 2719963679, ; 417: System.Security.Cryptography.Cng.dll => 0xa21f5a1f => 119
	i32 2724373263, ; 418: System.Runtime.Numerics.dll => 0xa262a30f => 109
	i32 2732626843, ; 419: Xamarin.AndroidX.Activity => 0xa2e0939b => 206
	i32 2735172069, ; 420: System.Threading.Channels => 0xa30769e5 => 136
	i32 2737747696, ; 421: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0xa32eb6f0 => 212
	i32 2740948882, ; 422: System.IO.Pipes.AccessControl => 0xa35f8f92 => 53
	i32 2748088231, ; 423: System.Runtime.InteropServices.JavaScript => 0xa3cc7fa7 => 104
	i32 2752995522, ; 424: pt-BR\Microsoft.Maui.Controls.resources => 0xa41760c2 => 306
	i32 2758225723, ; 425: Microsoft.Maui.Controls.Xaml => 0xa4672f3b => 190
	i32 2764765095, ; 426: Microsoft.Maui.dll => 0xa4caf7a7 => 191
	i32 2765824710, ; 427: System.Text.Encoding.CodePages.dll => 0xa4db22c6 => 132
	i32 2770495804, ; 428: Xamarin.Jetbrains.Annotations.dll => 0xa522693c => 278
	i32 2778768386, ; 429: Xamarin.AndroidX.ViewPager.dll => 0xa5a0a402 => 269
	i32 2779977773, ; 430: Xamarin.AndroidX.ResourceInspection.Annotation.dll => 0xa5b3182d => 257
	i32 2785988530, ; 431: th\Microsoft.Maui.Controls.resources => 0xa60ecfb2 => 312
	i32 2788224221, ; 432: Xamarin.AndroidX.Fragment.Ktx.dll => 0xa630ecdd => 235
	i32 2801831435, ; 433: Microsoft.Maui.Graphics => 0xa7008e0b => 193
	i32 2803228030, ; 434: System.Xml.XPath.XDocument.dll => 0xa715dd7e => 156
	i32 2806116107, ; 435: es/Microsoft.Maui.Controls.resources.dll => 0xa741ef0b => 291
	i32 2810250172, ; 436: Xamarin.AndroidX.CoordinatorLayout.dll => 0xa78103bc => 222
	i32 2819470561, ; 437: System.Xml.dll => 0xa80db4e1 => 160
	i32 2821205001, ; 438: System.ServiceProcess.dll => 0xa8282c09 => 131
	i32 2821294376, ; 439: Xamarin.AndroidX.ResourceInspection.Annotation => 0xa8298928 => 257
	i32 2824502124, ; 440: System.Xml.XmlDocument => 0xa85a7b6c => 158
	i32 2831556043, ; 441: nl/Microsoft.Maui.Controls.resources.dll => 0xa8c61dcb => 304
	i32 2838993487, ; 442: Xamarin.AndroidX.Lifecycle.ViewModel.Ktx.dll => 0xa9379a4f => 246
	i32 2847789619, ; 443: Microsoft.EntityFrameworkCore.Relational => 0xa9bdd233 => 174
	i32 2849599387, ; 444: System.Threading.Overlapped.dll => 0xa9d96f9b => 137
	i32 2853208004, ; 445: Xamarin.AndroidX.ViewPager => 0xaa107fc4 => 269
	i32 2855708567, ; 446: Xamarin.AndroidX.Transition => 0xaa36a797 => 265
	i32 2861098320, ; 447: Mono.Android.Export.dll => 0xaa88e550 => 166
	i32 2861189240, ; 448: Microsoft.Maui.Essentials => 0xaa8a4878 => 192
	i32 2870099610, ; 449: Xamarin.AndroidX.Activity.Ktx.dll => 0xab123e9a => 207
	i32 2875164099, ; 450: Jsr305Binding.dll => 0xab5f85c3 => 274
	i32 2875220617, ; 451: System.Globalization.Calendars.dll => 0xab606289 => 39
	i32 2884993177, ; 452: Xamarin.AndroidX.ExifInterface => 0xabf58099 => 233
	i32 2887636118, ; 453: System.Net.dll => 0xac1dd496 => 80
	i32 2899753641, ; 454: System.IO.UnmanagedMemoryStream => 0xacd6baa9 => 55
	i32 2900621748, ; 455: System.Dynamic.Runtime.dll => 0xace3f9b4 => 36
	i32 2901442782, ; 456: System.Reflection => 0xacf080de => 96
	i32 2905242038, ; 457: mscorlib.dll => 0xad2a79b6 => 163
	i32 2909740682, ; 458: System.Private.CoreLib => 0xad6f1e8a => 169
	i32 2916838712, ; 459: Xamarin.AndroidX.ViewPager2.dll => 0xaddb6d38 => 270
	i32 2919462931, ; 460: System.Numerics.Vectors.dll => 0xae037813 => 81
	i32 2921128767, ; 461: Xamarin.AndroidX.Annotation.Experimental.dll => 0xae1ce33f => 209
	i32 2936416060, ; 462: System.Resources.Reader => 0xaf06273c => 97
	i32 2940926066, ; 463: System.Diagnostics.StackTrace.dll => 0xaf4af872 => 29
	i32 2942453041, ; 464: System.Xml.XPath.XDocument => 0xaf624531 => 156
	i32 2959614098, ; 465: System.ComponentModel.dll => 0xb0682092 => 18
	i32 2968338931, ; 466: System.Security.Principal.Windows => 0xb0ed41f3 => 126
	i32 2972252294, ; 467: System.Security.Cryptography.Algorithms.dll => 0xb128f886 => 118
	i32 2978675010, ; 468: Xamarin.AndroidX.DrawerLayout => 0xb18af942 => 229
	i32 2987532451, ; 469: Xamarin.AndroidX.Security.SecurityCrypto => 0xb21220a3 => 260
	i32 2996846495, ; 470: Xamarin.AndroidX.Lifecycle.Process.dll => 0xb2a03f9f => 242
	i32 3016983068, ; 471: Xamarin.AndroidX.Startup.StartupRuntime => 0xb3d3821c => 262
	i32 3023353419, ; 472: WindowsBase.dll => 0xb434b64b => 162
	i32 3024354802, ; 473: Xamarin.AndroidX.Legacy.Support.Core.Utils => 0xb443fdf2 => 237
	i32 3038032645, ; 474: _Microsoft.Android.Resource.Designer.dll => 0xb514b305 => 323
	i32 3056245963, ; 475: Xamarin.AndroidX.SavedState.SavedState.Ktx => 0xb62a9ccb => 259
	i32 3057625584, ; 476: Xamarin.AndroidX.Navigation.Common => 0xb63fa9f0 => 250
	i32 3059408633, ; 477: Mono.Android.Runtime => 0xb65adef9 => 167
	i32 3059793426, ; 478: System.ComponentModel.Primitives => 0xb660be12 => 16
	i32 3069363400, ; 479: Microsoft.Extensions.Caching.Abstractions.dll => 0xb6f2c4c8 => 176
	i32 3075834255, ; 480: System.Threading.Tasks => 0xb755818f => 141
	i32 3077302341, ; 481: hu/Microsoft.Maui.Controls.resources.dll => 0xb76be845 => 297
	i32 3090735792, ; 482: System.Security.Cryptography.X509Certificates.dll => 0xb838e2b0 => 124
	i32 3099732863, ; 483: System.Security.Claims.dll => 0xb8c22b7f => 117
	i32 3103600923, ; 484: System.Formats.Asn1 => 0xb8fd311b => 37
	i32 3111772706, ; 485: System.Runtime.Serialization => 0xb979e222 => 114
	i32 3121463068, ; 486: System.IO.FileSystem.AccessControl.dll => 0xba0dbf1c => 46
	i32 3124832203, ; 487: System.Threading.Tasks.Extensions => 0xba4127cb => 139
	i32 3132293585, ; 488: System.Security.AccessControl => 0xbab301d1 => 116
	i32 3147165239, ; 489: System.Diagnostics.Tracing.dll => 0xbb95ee37 => 33
	i32 3148237826, ; 490: GoogleGson.dll => 0xbba64c02 => 170
	i32 3159123045, ; 491: System.Reflection.Primitives.dll => 0xbc4c6465 => 94
	i32 3160747431, ; 492: System.IO.MemoryMappedFiles => 0xbc652da7 => 52
	i32 3178803400, ; 493: Xamarin.AndroidX.Navigation.Fragment.dll => 0xbd78b0c8 => 251
	i32 3192346100, ; 494: System.Security.SecureString => 0xbe4755f4 => 128
	i32 3193515020, ; 495: System.Web => 0xbe592c0c => 150
	i32 3195844289, ; 496: Microsoft.Extensions.Caching.Abstractions => 0xbe7cb6c1 => 176
	i32 3204380047, ; 497: System.Data.dll => 0xbefef58f => 24
	i32 3209718065, ; 498: System.Xml.XmlDocument.dll => 0xbf506931 => 158
	i32 3211777861, ; 499: Xamarin.AndroidX.DocumentFile => 0xbf6fd745 => 228
	i32 3217618498, ; 500: Microsoft.VisualStudio.DesignTools.XamlTapContract => 0xbfc8f642 => 322
	i32 3220365878, ; 501: System.Threading => 0xbff2e236 => 145
	i32 3226221578, ; 502: System.Runtime.Handles.dll => 0xc04c3c0a => 103
	i32 3251039220, ; 503: System.Reflection.DispatchProxy.dll => 0xc1c6ebf4 => 88
	i32 3258312781, ; 504: Xamarin.AndroidX.CardView => 0xc235e84d => 216
	i32 3265493905, ; 505: System.Linq.Queryable.dll => 0xc2a37b91 => 59
	i32 3265893370, ; 506: System.Threading.Tasks.Extensions.dll => 0xc2a993fa => 139
	i32 3277815716, ; 507: System.Resources.Writer.dll => 0xc35f7fa4 => 99
	i32 3279906254, ; 508: Microsoft.Win32.Registry.dll => 0xc37f65ce => 5
	i32 3280506390, ; 509: System.ComponentModel.Annotations.dll => 0xc3888e16 => 13
	i32 3290767353, ; 510: System.Security.Cryptography.Encoding => 0xc4251ff9 => 121
	i32 3299363146, ; 511: System.Text.Encoding => 0xc4a8494a => 134
	i32 3303498502, ; 512: System.Diagnostics.FileVersionInfo => 0xc4e76306 => 27
	i32 3305363605, ; 513: fi\Microsoft.Maui.Controls.resources => 0xc503d895 => 292
	i32 3316684772, ; 514: System.Net.Requests.dll => 0xc5b097e4 => 71
	i32 3317135071, ; 515: Xamarin.AndroidX.CustomView.dll => 0xc5b776df => 226
	i32 3317144872, ; 516: System.Data => 0xc5b79d28 => 24
	i32 3340431453, ; 517: Xamarin.AndroidX.Arch.Core.Runtime => 0xc71af05d => 214
	i32 3345895724, ; 518: Xamarin.AndroidX.ProfileInstaller.ProfileInstaller.dll => 0xc76e512c => 255
	i32 3346324047, ; 519: Xamarin.AndroidX.Navigation.Runtime => 0xc774da4f => 252
	i32 3357674450, ; 520: ru\Microsoft.Maui.Controls.resources => 0xc8220bd2 => 309
	i32 3358260929, ; 521: System.Text.Json => 0xc82afec1 => 201
	i32 3360279109, ; 522: SQLitePCLRaw.core => 0xc849ca45 => 195
	i32 3362336904, ; 523: Xamarin.AndroidX.Activity.Ktx => 0xc8693088 => 207
	i32 3362522851, ; 524: Xamarin.AndroidX.Core => 0xc86c06e3 => 223
	i32 3366347497, ; 525: Java.Interop => 0xc8a662e9 => 165
	i32 3374999561, ; 526: Xamarin.AndroidX.RecyclerView => 0xc92a6809 => 256
	i32 3381016424, ; 527: da\Microsoft.Maui.Controls.resources => 0xc9863768 => 288
	i32 3395150330, ; 528: System.Runtime.CompilerServices.Unsafe.dll => 0xca5de1fa => 100
	i32 3403906625, ; 529: System.Security.Cryptography.OpenSsl.dll => 0xcae37e41 => 122
	i32 3405233483, ; 530: Xamarin.AndroidX.CustomView.PoolingContainer => 0xcaf7bd4b => 227
	i32 3428513518, ; 531: Microsoft.Extensions.DependencyInjection.dll => 0xcc5af6ee => 180
	i32 3429136800, ; 532: System.Xml => 0xcc6479a0 => 160
	i32 3430777524, ; 533: netstandard => 0xcc7d82b4 => 164
	i32 3441283291, ; 534: Xamarin.AndroidX.DynamicAnimation.dll => 0xcd1dd0db => 230
	i32 3445260447, ; 535: System.Formats.Tar => 0xcd5a809f => 38
	i32 3452344032, ; 536: Microsoft.Maui.Controls.Compatibility.dll => 0xcdc696e0 => 188
	i32 3463511458, ; 537: hr/Microsoft.Maui.Controls.resources.dll => 0xce70fda2 => 296
	i32 3471940407, ; 538: System.ComponentModel.TypeConverter.dll => 0xcef19b37 => 17
	i32 3476120550, ; 539: Mono.Android => 0xcf3163e6 => 168
	i32 3479583265, ; 540: ru/Microsoft.Maui.Controls.resources.dll => 0xcf663a21 => 309
	i32 3484440000, ; 541: ro\Microsoft.Maui.Controls.resources => 0xcfb055c0 => 308
	i32 3485117614, ; 542: System.Text.Json.dll => 0xcfbaacae => 201
	i32 3486566296, ; 543: System.Transactions => 0xcfd0c798 => 147
	i32 3493954962, ; 544: Xamarin.AndroidX.Concurrent.Futures.dll => 0xd0418592 => 219
	i32 3509114376, ; 545: System.Xml.Linq => 0xd128d608 => 152
	i32 3515174580, ; 546: System.Security.dll => 0xd1854eb4 => 129
	i32 3530912306, ; 547: System.Configuration => 0xd2757232 => 19
	i32 3539954161, ; 548: System.Net.HttpListener => 0xd2ff69f1 => 64
	i32 3560100363, ; 549: System.Threading.Timer => 0xd432d20b => 144
	i32 3570554715, ; 550: System.IO.FileSystem.AccessControl => 0xd4d2575b => 46
	i32 3580758918, ; 551: zh-HK\Microsoft.Maui.Controls.resources => 0xd56e0b86 => 316
	i32 3597029428, ; 552: Xamarin.Android.Glide.GifDecoder.dll => 0xd6665034 => 205
	i32 3598340787, ; 553: System.Net.WebSockets.Client => 0xd67a52b3 => 78
	i32 3608519521, ; 554: System.Linq.dll => 0xd715a361 => 60
	i32 3624195450, ; 555: System.Runtime.InteropServices.RuntimeInformation => 0xd804d57a => 105
	i32 3627220390, ; 556: Xamarin.AndroidX.Print.dll => 0xd832fda6 => 254
	i32 3633644679, ; 557: Xamarin.AndroidX.Annotation.Experimental => 0xd8950487 => 209
	i32 3638274909, ; 558: System.IO.FileSystem.Primitives.dll => 0xd8dbab5d => 48
	i32 3641597786, ; 559: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0xd90e5f5a => 240
	i32 3643446276, ; 560: tr\Microsoft.Maui.Controls.resources => 0xd92a9404 => 313
	i32 3643854240, ; 561: Xamarin.AndroidX.Navigation.Fragment => 0xd930cda0 => 251
	i32 3645089577, ; 562: System.ComponentModel.DataAnnotations => 0xd943a729 => 14
	i32 3657292374, ; 563: Microsoft.Extensions.Configuration.Abstractions.dll => 0xd9fdda56 => 179
	i32 3660523487, ; 564: System.Net.NetworkInformation => 0xda2f27df => 67
	i32 3672681054, ; 565: Mono.Android.dll => 0xdae8aa5e => 168
	i32 3676670898, ; 566: Microsoft.Maui.Controls.HotReload.Forms => 0xdb258bb2 => 319
	i32 3682565725, ; 567: Xamarin.AndroidX.Browser => 0xdb7f7e5d => 215
	i32 3684561358, ; 568: Xamarin.AndroidX.Concurrent.Futures => 0xdb9df1ce => 219
	i32 3697841164, ; 569: zh-Hant/Microsoft.Maui.Controls.resources.dll => 0xdc68940c => 318
	i32 3700866549, ; 570: System.Net.WebProxy.dll => 0xdc96bdf5 => 77
	i32 3706696989, ; 571: Xamarin.AndroidX.Core.Core.Ktx.dll => 0xdcefb51d => 224
	i32 3716563718, ; 572: System.Runtime.Intrinsics => 0xdd864306 => 107
	i32 3718780102, ; 573: Xamarin.AndroidX.Annotation => 0xdda814c6 => 208
	i32 3724971120, ; 574: Xamarin.AndroidX.Navigation.Common.dll => 0xde068c70 => 250
	i32 3732100267, ; 575: System.Net.NameResolution => 0xde7354ab => 66
	i32 3737834244, ; 576: System.Net.Http.Json.dll => 0xdecad304 => 62
	i32 3748608112, ; 577: System.Diagnostics.DiagnosticSource => 0xdf6f3870 => 198
	i32 3751444290, ; 578: System.Xml.XPath => 0xdf9a7f42 => 157
	i32 3754567612, ; 579: SQLitePCLRaw.provider.e_sqlite3 => 0xdfca27bc => 197
	i32 3786282454, ; 580: Xamarin.AndroidX.Collection => 0xe1ae15d6 => 217
	i32 3792276235, ; 581: System.Collections.NonGeneric => 0xe2098b0b => 10
	i32 3800979733, ; 582: Microsoft.Maui.Controls.Compatibility => 0xe28e5915 => 188
	i32 3802395368, ; 583: System.Collections.Specialized.dll => 0xe2a3f2e8 => 11
	i32 3819260425, ; 584: System.Net.WebProxy => 0xe3a54a09 => 77
	i32 3823082795, ; 585: System.Security.Cryptography.dll => 0xe3df9d2b => 125
	i32 3829621856, ; 586: System.Numerics.dll => 0xe4436460 => 82
	i32 3841636137, ; 587: Microsoft.Extensions.DependencyInjection.Abstractions.dll => 0xe4fab729 => 181
	i32 3844307129, ; 588: System.Net.Mail.dll => 0xe52378b9 => 65
	i32 3849253459, ; 589: System.Runtime.InteropServices.dll => 0xe56ef253 => 106
	i32 3870376305, ; 590: System.Net.HttpListener.dll => 0xe6b14171 => 64
	i32 3873536506, ; 591: System.Security.Principal => 0xe6e179fa => 127
	i32 3875112723, ; 592: System.Security.Cryptography.Encoding.dll => 0xe6f98713 => 121
	i32 3885497537, ; 593: System.Net.WebHeaderCollection.dll => 0xe797fcc1 => 76
	i32 3885922214, ; 594: Xamarin.AndroidX.Transition.dll => 0xe79e77a6 => 265
	i32 3888767677, ; 595: Xamarin.AndroidX.ProfileInstaller.ProfileInstaller => 0xe7c9e2bd => 255
	i32 3889960447, ; 596: zh-Hans/Microsoft.Maui.Controls.resources.dll => 0xe7dc15ff => 317
	i32 3896106733, ; 597: System.Collections.Concurrent.dll => 0xe839deed => 8
	i32 3896760992, ; 598: Xamarin.AndroidX.Core.dll => 0xe843daa0 => 223
	i32 3901907137, ; 599: Microsoft.VisualBasic.Core.dll => 0xe89260c1 => 2
	i32 3920810846, ; 600: System.IO.Compression.FileSystem.dll => 0xe9b2d35e => 43
	i32 3921031405, ; 601: Xamarin.AndroidX.VersionedParcelable.dll => 0xe9b630ed => 268
	i32 3928044579, ; 602: System.Xml.ReaderWriter => 0xea213423 => 153
	i32 3930554604, ; 603: System.Security.Principal.dll => 0xea4780ec => 127
	i32 3931092270, ; 604: Xamarin.AndroidX.Navigation.UI => 0xea4fb52e => 253
	i32 3945713374, ; 605: System.Data.DataSetExtensions.dll => 0xeb2ecede => 23
	i32 3953953790, ; 606: System.Text.Encoding.CodePages => 0xebac8bfe => 132
	i32 3955647286, ; 607: Xamarin.AndroidX.AppCompat.dll => 0xebc66336 => 211
	i32 3959773229, ; 608: Xamarin.AndroidX.Lifecycle.Process => 0xec05582d => 242
	i32 3980434154, ; 609: th/Microsoft.Maui.Controls.resources.dll => 0xed409aea => 312
	i32 3987592930, ; 610: he/Microsoft.Maui.Controls.resources.dll => 0xedadd6e2 => 294
	i32 4003436829, ; 611: System.Diagnostics.Process.dll => 0xee9f991d => 28
	i32 4015948917, ; 612: Xamarin.AndroidX.Annotation.Jvm.dll => 0xef5e8475 => 210
	i32 4023392905, ; 613: System.IO.Pipelines => 0xefd01a89 => 199
	i32 4025784931, ; 614: System.Memory => 0xeff49a63 => 61
	i32 4046471985, ; 615: Microsoft.Maui.Controls.Xaml.dll => 0xf1304331 => 190
	i32 4054681211, ; 616: System.Reflection.Emit.ILGeneration => 0xf1ad867b => 89
	i32 4068434129, ; 617: System.Private.Xml.Linq.dll => 0xf27f60d1 => 86
	i32 4073602200, ; 618: System.Threading.dll => 0xf2ce3c98 => 145
	i32 4094352644, ; 619: Microsoft.Maui.Essentials.dll => 0xf40add04 => 192
	i32 4099507663, ; 620: System.Drawing.dll => 0xf45985cf => 35
	i32 4100113165, ; 621: System.Private.Uri => 0xf462c30d => 85
	i32 4101593132, ; 622: Xamarin.AndroidX.Emoji2 => 0xf479582c => 231
	i32 4101842092, ; 623: Microsoft.Extensions.Caching.Memory => 0xf47d24ac => 177
	i32 4102112229, ; 624: pt/Microsoft.Maui.Controls.resources.dll => 0xf48143e5 => 307
	i32 4125707920, ; 625: ms/Microsoft.Maui.Controls.resources.dll => 0xf5e94e90 => 302
	i32 4126470640, ; 626: Microsoft.Extensions.DependencyInjection => 0xf5f4f1f0 => 180
	i32 4127667938, ; 627: System.IO.FileSystem.Watcher => 0xf60736e2 => 49
	i32 4130442656, ; 628: System.AppContext => 0xf6318da0 => 6
	i32 4147896353, ; 629: System.Reflection.Emit.ILGeneration.dll => 0xf73be021 => 89
	i32 4150914736, ; 630: uk\Microsoft.Maui.Controls.resources => 0xf769eeb0 => 314
	i32 4151237749, ; 631: System.Core => 0xf76edc75 => 21
	i32 4159265925, ; 632: System.Xml.XmlSerializer => 0xf7e95c85 => 159
	i32 4161255271, ; 633: System.Reflection.TypeExtensions => 0xf807b767 => 95
	i32 4164802419, ; 634: System.IO.FileSystem.Watcher.dll => 0xf83dd773 => 49
	i32 4181436372, ; 635: System.Runtime.Serialization.Primitives => 0xf93ba7d4 => 112
	i32 4182413190, ; 636: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0xf94a8f86 => 247
	i32 4182880526, ; 637: Microsoft.VisualStudio.DesignTools.MobileTapContracts => 0xf951b10e => 320
	i32 4185676441, ; 638: System.Security => 0xf97c5a99 => 129
	i32 4196529839, ; 639: System.Net.WebClient.dll => 0xfa21f6af => 75
	i32 4213026141, ; 640: System.Diagnostics.DiagnosticSource.dll => 0xfb1dad5d => 198
	i32 4256097574, ; 641: Xamarin.AndroidX.Core.Core.Ktx => 0xfdaee526 => 224
	i32 4258378803, ; 642: Xamarin.AndroidX.Lifecycle.ViewModel.Ktx => 0xfdd1b433 => 246
	i32 4260525087, ; 643: System.Buffers => 0xfdf2741f => 7
	i32 4271975918, ; 644: Microsoft.Maui.Controls.dll => 0xfea12dee => 189
	i32 4274976490, ; 645: System.Runtime.Numerics => 0xfecef6ea => 109
	i32 4292120959, ; 646: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xffd4917f => 247
	i32 4294763496 ; 647: Xamarin.AndroidX.ExifInterface.dll => 0xfffce3e8 => 233
], align 4

@assembly_image_cache_indices = dso_local local_unnamed_addr constant [648 x i32] [
	i32 67, ; 0
	i32 66, ; 1
	i32 107, ; 2
	i32 182, ; 3
	i32 243, ; 4
	i32 277, ; 5
	i32 47, ; 6
	i32 79, ; 7
	i32 142, ; 8
	i32 29, ; 9
	i32 318, ; 10
	i32 123, ; 11
	i32 193, ; 12
	i32 101, ; 13
	i32 261, ; 14
	i32 106, ; 15
	i32 261, ; 16
	i32 136, ; 17
	i32 281, ; 18
	i32 76, ; 19
	i32 123, ; 20
	i32 13, ; 21
	i32 217, ; 22
	i32 131, ; 23
	i32 263, ; 24
	i32 148, ; 25
	i32 315, ; 26
	i32 316, ; 27
	i32 18, ; 28
	i32 215, ; 29
	i32 26, ; 30
	i32 237, ; 31
	i32 1, ; 32
	i32 58, ; 33
	i32 41, ; 34
	i32 90, ; 35
	i32 220, ; 36
	i32 144, ; 37
	i32 239, ; 38
	i32 236, ; 39
	i32 287, ; 40
	i32 53, ; 41
	i32 68, ; 42
	i32 315, ; 43
	i32 206, ; 44
	i32 82, ; 45
	i32 300, ; 46
	i32 238, ; 47
	i32 196, ; 48
	i32 299, ; 49
	i32 130, ; 50
	i32 54, ; 51
	i32 146, ; 52
	i32 73, ; 53
	i32 142, ; 54
	i32 61, ; 55
	i32 143, ; 56
	i32 323, ; 57
	i32 162, ; 58
	i32 311, ; 59
	i32 221, ; 60
	i32 12, ; 61
	i32 234, ; 62
	i32 124, ; 63
	i32 149, ; 64
	i32 112, ; 65
	i32 163, ; 66
	i32 161, ; 67
	i32 236, ; 68
	i32 249, ; 69
	i32 83, ; 70
	i32 298, ; 71
	i32 292, ; 72
	i32 187, ; 73
	i32 147, ; 74
	i32 281, ; 75
	i32 59, ; 76
	i32 183, ; 77
	i32 50, ; 78
	i32 102, ; 79
	i32 113, ; 80
	i32 39, ; 81
	i32 274, ; 82
	i32 272, ; 83
	i32 119, ; 84
	i32 306, ; 85
	i32 51, ; 86
	i32 43, ; 87
	i32 118, ; 88
	i32 226, ; 89
	i32 304, ; 90
	i32 232, ; 91
	i32 80, ; 92
	i32 200, ; 93
	i32 268, ; 94
	i32 213, ; 95
	i32 8, ; 96
	i32 72, ; 97
	i32 286, ; 98
	i32 152, ; 99
	i32 283, ; 100
	i32 151, ; 101
	i32 91, ; 102
	i32 278, ; 103
	i32 44, ; 104
	i32 301, ; 105
	i32 289, ; 106
	i32 282, ; 107
	i32 108, ; 108
	i32 128, ; 109
	i32 194, ; 110
	i32 25, ; 111
	i32 203, ; 112
	i32 71, ; 113
	i32 54, ; 114
	i32 45, ; 115
	i32 310, ; 116
	i32 186, ; 117
	i32 227, ; 118
	i32 22, ; 119
	i32 241, ; 120
	i32 85, ; 121
	i32 42, ; 122
	i32 157, ; 123
	i32 70, ; 124
	i32 254, ; 125
	i32 3, ; 126
	i32 41, ; 127
	i32 62, ; 128
	i32 16, ; 129
	i32 52, ; 130
	i32 313, ; 131
	i32 277, ; 132
	i32 104, ; 133
	i32 282, ; 134
	i32 275, ; 135
	i32 238, ; 136
	i32 33, ; 137
	i32 155, ; 138
	i32 84, ; 139
	i32 31, ; 140
	i32 12, ; 141
	i32 50, ; 142
	i32 55, ; 143
	i32 258, ; 144
	i32 35, ; 145
	i32 181, ; 146
	i32 288, ; 147
	i32 276, ; 148
	i32 211, ; 149
	i32 34, ; 150
	i32 57, ; 151
	i32 245, ; 152
	i32 170, ; 153
	i32 17, ; 154
	i32 279, ; 155
	i32 161, ; 156
	i32 301, ; 157
	i32 244, ; 158
	i32 185, ; 159
	i32 271, ; 160
	i32 173, ; 161
	i32 307, ; 162
	i32 150, ; 163
	i32 267, ; 164
	i32 252, ; 165
	i32 173, ; 166
	i32 305, ; 167
	i32 213, ; 168
	i32 177, ; 169
	i32 28, ; 170
	i32 51, ; 171
	i32 303, ; 172
	i32 272, ; 173
	i32 5, ; 174
	i32 287, ; 175
	i32 262, ; 176
	i32 266, ; 177
	i32 218, ; 178
	i32 283, ; 179
	i32 210, ; 180
	i32 195, ; 181
	i32 229, ; 182
	i32 84, ; 183
	i32 0, ; 184
	i32 271, ; 185
	i32 60, ; 186
	i32 111, ; 187
	i32 56, ; 188
	i32 317, ; 189
	i32 258, ; 190
	i32 98, ; 191
	i32 19, ; 192
	i32 222, ; 193
	i32 110, ; 194
	i32 100, ; 195
	i32 101, ; 196
	i32 285, ; 197
	i32 103, ; 198
	i32 275, ; 199
	i32 70, ; 200
	i32 37, ; 201
	i32 31, ; 202
	i32 102, ; 203
	i32 72, ; 204
	i32 291, ; 205
	i32 9, ; 206
	i32 122, ; 207
	i32 45, ; 208
	i32 212, ; 209
	i32 187, ; 210
	i32 9, ; 211
	i32 42, ; 212
	i32 4, ; 213
	i32 259, ; 214
	i32 171, ; 215
	i32 295, ; 216
	i32 290, ; 217
	i32 30, ; 218
	i32 135, ; 219
	i32 91, ; 220
	i32 92, ; 221
	i32 310, ; 222
	i32 48, ; 223
	i32 138, ; 224
	i32 111, ; 225
	i32 137, ; 226
	i32 228, ; 227
	i32 114, ; 228
	i32 276, ; 229
	i32 154, ; 230
	i32 319, ; 231
	i32 75, ; 232
	i32 78, ; 233
	i32 248, ; 234
	i32 36, ; 235
	i32 270, ; 236
	i32 232, ; 237
	i32 225, ; 238
	i32 63, ; 239
	i32 135, ; 240
	i32 15, ; 241
	i32 115, ; 242
	i32 264, ; 243
	i32 273, ; 244
	i32 220, ; 245
	i32 47, ; 246
	i32 69, ; 247
	i32 79, ; 248
	i32 125, ; 249
	i32 171, ; 250
	i32 172, ; 251
	i32 93, ; 252
	i32 120, ; 253
	i32 280, ; 254
	i32 26, ; 255
	i32 196, ; 256
	i32 241, ; 257
	i32 96, ; 258
	i32 27, ; 259
	i32 216, ; 260
	i32 308, ; 261
	i32 286, ; 262
	i32 146, ; 263
	i32 199, ; 264
	i32 166, ; 265
	i32 4, ; 266
	i32 0, ; 267
	i32 97, ; 268
	i32 32, ; 269
	i32 92, ; 270
	i32 263, ; 271
	i32 183, ; 272
	i32 21, ; 273
	i32 40, ; 274
	i32 167, ; 275
	i32 302, ; 276
	i32 234, ; 277
	i32 294, ; 278
	i32 248, ; 279
	i32 279, ; 280
	i32 273, ; 281
	i32 253, ; 282
	i32 2, ; 283
	i32 133, ; 284
	i32 110, ; 285
	i32 321, ; 286
	i32 184, ; 287
	i32 314, ; 288
	i32 203, ; 289
	i32 311, ; 290
	i32 57, ; 291
	i32 94, ; 292
	i32 293, ; 293
	i32 38, ; 294
	i32 214, ; 295
	i32 321, ; 296
	i32 175, ; 297
	i32 25, ; 298
	i32 93, ; 299
	i32 88, ; 300
	i32 98, ; 301
	i32 10, ; 302
	i32 86, ; 303
	i32 99, ; 304
	i32 260, ; 305
	i32 178, ; 306
	i32 280, ; 307
	i32 205, ; 308
	i32 290, ; 309
	i32 7, ; 310
	i32 175, ; 311
	i32 245, ; 312
	i32 285, ; 313
	i32 202, ; 314
	i32 87, ; 315
	i32 240, ; 316
	i32 151, ; 317
	i32 289, ; 318
	i32 32, ; 319
	i32 115, ; 320
	i32 81, ; 321
	i32 197, ; 322
	i32 322, ; 323
	i32 20, ; 324
	i32 11, ; 325
	i32 159, ; 326
	i32 3, ; 327
	i32 191, ; 328
	i32 297, ; 329
	i32 186, ; 330
	i32 184, ; 331
	i32 83, ; 332
	i32 182, ; 333
	i32 284, ; 334
	i32 63, ; 335
	i32 299, ; 336
	i32 267, ; 337
	i32 140, ; 338
	i32 249, ; 339
	i32 154, ; 340
	i32 172, ; 341
	i32 40, ; 342
	i32 116, ; 343
	i32 179, ; 344
	i32 204, ; 345
	i32 293, ; 346
	i32 256, ; 347
	i32 130, ; 348
	i32 74, ; 349
	i32 65, ; 350
	i32 303, ; 351
	i32 169, ; 352
	i32 208, ; 353
	i32 140, ; 354
	i32 105, ; 355
	i32 148, ; 356
	i32 69, ; 357
	i32 153, ; 358
	i32 178, ; 359
	i32 120, ; 360
	i32 126, ; 361
	i32 298, ; 362
	i32 149, ; 363
	i32 231, ; 364
	i32 320, ; 365
	i32 138, ; 366
	i32 218, ; 367
	i32 295, ; 368
	i32 20, ; 369
	i32 14, ; 370
	i32 134, ; 371
	i32 74, ; 372
	i32 58, ; 373
	i32 194, ; 374
	i32 221, ; 375
	i32 164, ; 376
	i32 165, ; 377
	i32 189, ; 378
	i32 15, ; 379
	i32 73, ; 380
	i32 6, ; 381
	i32 23, ; 382
	i32 243, ; 383
	i32 202, ; 384
	i32 90, ; 385
	i32 296, ; 386
	i32 1, ; 387
	i32 200, ; 388
	i32 244, ; 389
	i32 266, ; 390
	i32 133, ; 391
	i32 68, ; 392
	i32 143, ; 393
	i32 305, ; 394
	i32 284, ; 395
	i32 235, ; 396
	i32 185, ; 397
	i32 87, ; 398
	i32 95, ; 399
	i32 225, ; 400
	i32 230, ; 401
	i32 300, ; 402
	i32 30, ; 403
	i32 44, ; 404
	i32 239, ; 405
	i32 174, ; 406
	i32 204, ; 407
	i32 108, ; 408
	i32 155, ; 409
	i32 34, ; 410
	i32 22, ; 411
	i32 113, ; 412
	i32 56, ; 413
	i32 264, ; 414
	i32 141, ; 415
	i32 117, ; 416
	i32 119, ; 417
	i32 109, ; 418
	i32 206, ; 419
	i32 136, ; 420
	i32 212, ; 421
	i32 53, ; 422
	i32 104, ; 423
	i32 306, ; 424
	i32 190, ; 425
	i32 191, ; 426
	i32 132, ; 427
	i32 278, ; 428
	i32 269, ; 429
	i32 257, ; 430
	i32 312, ; 431
	i32 235, ; 432
	i32 193, ; 433
	i32 156, ; 434
	i32 291, ; 435
	i32 222, ; 436
	i32 160, ; 437
	i32 131, ; 438
	i32 257, ; 439
	i32 158, ; 440
	i32 304, ; 441
	i32 246, ; 442
	i32 174, ; 443
	i32 137, ; 444
	i32 269, ; 445
	i32 265, ; 446
	i32 166, ; 447
	i32 192, ; 448
	i32 207, ; 449
	i32 274, ; 450
	i32 39, ; 451
	i32 233, ; 452
	i32 80, ; 453
	i32 55, ; 454
	i32 36, ; 455
	i32 96, ; 456
	i32 163, ; 457
	i32 169, ; 458
	i32 270, ; 459
	i32 81, ; 460
	i32 209, ; 461
	i32 97, ; 462
	i32 29, ; 463
	i32 156, ; 464
	i32 18, ; 465
	i32 126, ; 466
	i32 118, ; 467
	i32 229, ; 468
	i32 260, ; 469
	i32 242, ; 470
	i32 262, ; 471
	i32 162, ; 472
	i32 237, ; 473
	i32 323, ; 474
	i32 259, ; 475
	i32 250, ; 476
	i32 167, ; 477
	i32 16, ; 478
	i32 176, ; 479
	i32 141, ; 480
	i32 297, ; 481
	i32 124, ; 482
	i32 117, ; 483
	i32 37, ; 484
	i32 114, ; 485
	i32 46, ; 486
	i32 139, ; 487
	i32 116, ; 488
	i32 33, ; 489
	i32 170, ; 490
	i32 94, ; 491
	i32 52, ; 492
	i32 251, ; 493
	i32 128, ; 494
	i32 150, ; 495
	i32 176, ; 496
	i32 24, ; 497
	i32 158, ; 498
	i32 228, ; 499
	i32 322, ; 500
	i32 145, ; 501
	i32 103, ; 502
	i32 88, ; 503
	i32 216, ; 504
	i32 59, ; 505
	i32 139, ; 506
	i32 99, ; 507
	i32 5, ; 508
	i32 13, ; 509
	i32 121, ; 510
	i32 134, ; 511
	i32 27, ; 512
	i32 292, ; 513
	i32 71, ; 514
	i32 226, ; 515
	i32 24, ; 516
	i32 214, ; 517
	i32 255, ; 518
	i32 252, ; 519
	i32 309, ; 520
	i32 201, ; 521
	i32 195, ; 522
	i32 207, ; 523
	i32 223, ; 524
	i32 165, ; 525
	i32 256, ; 526
	i32 288, ; 527
	i32 100, ; 528
	i32 122, ; 529
	i32 227, ; 530
	i32 180, ; 531
	i32 160, ; 532
	i32 164, ; 533
	i32 230, ; 534
	i32 38, ; 535
	i32 188, ; 536
	i32 296, ; 537
	i32 17, ; 538
	i32 168, ; 539
	i32 309, ; 540
	i32 308, ; 541
	i32 201, ; 542
	i32 147, ; 543
	i32 219, ; 544
	i32 152, ; 545
	i32 129, ; 546
	i32 19, ; 547
	i32 64, ; 548
	i32 144, ; 549
	i32 46, ; 550
	i32 316, ; 551
	i32 205, ; 552
	i32 78, ; 553
	i32 60, ; 554
	i32 105, ; 555
	i32 254, ; 556
	i32 209, ; 557
	i32 48, ; 558
	i32 240, ; 559
	i32 313, ; 560
	i32 251, ; 561
	i32 14, ; 562
	i32 179, ; 563
	i32 67, ; 564
	i32 168, ; 565
	i32 319, ; 566
	i32 215, ; 567
	i32 219, ; 568
	i32 318, ; 569
	i32 77, ; 570
	i32 224, ; 571
	i32 107, ; 572
	i32 208, ; 573
	i32 250, ; 574
	i32 66, ; 575
	i32 62, ; 576
	i32 198, ; 577
	i32 157, ; 578
	i32 197, ; 579
	i32 217, ; 580
	i32 10, ; 581
	i32 188, ; 582
	i32 11, ; 583
	i32 77, ; 584
	i32 125, ; 585
	i32 82, ; 586
	i32 181, ; 587
	i32 65, ; 588
	i32 106, ; 589
	i32 64, ; 590
	i32 127, ; 591
	i32 121, ; 592
	i32 76, ; 593
	i32 265, ; 594
	i32 255, ; 595
	i32 317, ; 596
	i32 8, ; 597
	i32 223, ; 598
	i32 2, ; 599
	i32 43, ; 600
	i32 268, ; 601
	i32 153, ; 602
	i32 127, ; 603
	i32 253, ; 604
	i32 23, ; 605
	i32 132, ; 606
	i32 211, ; 607
	i32 242, ; 608
	i32 312, ; 609
	i32 294, ; 610
	i32 28, ; 611
	i32 210, ; 612
	i32 199, ; 613
	i32 61, ; 614
	i32 190, ; 615
	i32 89, ; 616
	i32 86, ; 617
	i32 145, ; 618
	i32 192, ; 619
	i32 35, ; 620
	i32 85, ; 621
	i32 231, ; 622
	i32 177, ; 623
	i32 307, ; 624
	i32 302, ; 625
	i32 180, ; 626
	i32 49, ; 627
	i32 6, ; 628
	i32 89, ; 629
	i32 314, ; 630
	i32 21, ; 631
	i32 159, ; 632
	i32 95, ; 633
	i32 49, ; 634
	i32 112, ; 635
	i32 247, ; 636
	i32 320, ; 637
	i32 129, ; 638
	i32 75, ; 639
	i32 198, ; 640
	i32 224, ; 641
	i32 246, ; 642
	i32 7, ; 643
	i32 189, ; 644
	i32 109, ; 645
	i32 247, ; 646
	i32 233 ; 647
], align 4

@marshal_methods_number_of_classes = dso_local local_unnamed_addr constant i32 0, align 4

@marshal_methods_class_cache = dso_local local_unnamed_addr global [0 x %struct.MarshalMethodsManagedClass] zeroinitializer, align 4

; Names of classes in which marshal methods reside
@mm_class_names = dso_local local_unnamed_addr constant [0 x ptr] zeroinitializer, align 4

@mm_method_names = dso_local local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		ptr @.MarshalMethodName.0_name; char* name
	} ; 0
], align 8

; get_function_pointer (uint32_t mono_image_index, uint32_t class_index, uint32_t method_token, void*& target_ptr)
@get_function_pointer = internal dso_local unnamed_addr global ptr null, align 4

; Functions

; Function attributes: "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" uwtable willreturn
define void @xamarin_app_init(ptr nocapture noundef readnone %env, ptr noundef %fn) local_unnamed_addr #0
{
	%fnIsNull = icmp eq ptr %fn, null
	br i1 %fnIsNull, label %1, label %2

1: ; preds = %0
	%putsResult = call noundef i32 @puts(ptr @.str.0)
	call void @abort()
	unreachable 

2: ; preds = %1, %0
	store ptr %fn, ptr @get_function_pointer, align 4, !tbaa !3
	ret void
}

; Strings
@.str.0 = private unnamed_addr constant [40 x i8] c"get_function_pointer MUST be specified\0A\00", align 1

;MarshalMethodName
@.MarshalMethodName.0_name = private unnamed_addr constant [1 x i8] c"\00", align 1

; External functions

; Function attributes: noreturn "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8"
declare void @abort() local_unnamed_addr #2

; Function attributes: nofree nounwind
declare noundef i32 @puts(ptr noundef) local_unnamed_addr #1
attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-thumb-mode,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" uwtable willreturn }
attributes #1 = { nofree nounwind }
attributes #2 = { noreturn "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-thumb-mode,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" }

; Metadata
!llvm.module.flags = !{!0, !1, !7}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!llvm.ident = !{!2}
!2 = !{!"Xamarin.Android remotes/origin/release/8.0.4xx @ 82d8938cf80f6d5fa6c28529ddfbdb753d805ab4"}
!3 = !{!4, !4, i64 0}
!4 = !{!"any pointer", !5, i64 0}
!5 = !{!"omnipotent char", !6, i64 0}
!6 = !{!"Simple C++ TBAA"}
!7 = !{i32 1, !"min_enum_size", i32 4}
