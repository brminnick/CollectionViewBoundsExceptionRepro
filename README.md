# CollectionViewBoundsExceptionRepro

Reproduction Sample for Xamarin.Forms.CollectionView `NSRangeException`:

```bash
Objective-C exception thrown.  Name: NSRangeException Reason: *** -[__NSArrayM objectAtIndex:]: index 0 beyond bounds for empty array
```

### Reproduction Steps

1. Download / clone this repo
2. In Visual Studio, open `CollectionViewBoundsExceptionRepro.sln`
3. In Visual Studio, buld/deploy `CollectionViewBoundsExceptionRepro.iOS` to an iOS Simulator or Device 
4. Confirm `NSRangeException` is thrown on launch

## Work Arounds

#### Option #1. Downgrade Xamarin.Forms

Downgrade to Xamarin.Forms v4.7.0.937-pre4

#### Option #2. Remove CollectionView.Footer

Set `CollectionView.Footer = null`

https://github.com/brminnick/CollectionViewBoundsExceptionRepro/blob/8a6636d7af57f289113e800cfa0d0160cad78d6d/Src/CollectionViewBoundsExceptionRepro/CollectionViewPage.cs#L17

#### Option #3. Replace `IEnumerable<int>` with `ObservableCollection<int>`

1. In `CollectionViewModel.cs`, remove `public IEnumerable<int> ScoreCollectionList`
2. In `CollectionViewModel.cs`, remove `IEnumerable<int>? _scoreCollectionList;`
3. In `CollectionViewModel.cs`, add `public ObservableCollection<int> ScoreCollectionList { get; } = new ObservableCollection<int>()`
4. In `CollectionViewModel.cs`, in `ExecuteRefreshCommand` refactor logic for `ObservableCollection` : 

Replace this code:

```csharp
void ExecuteRefreshCommand()
{
    ScoreCollectionList = Enumerable.Range(0, 100).ToList();
    IsRefreshing = false;
}
```

with this code:

```csharp
void ExecuteRefreshCommand()
{
    foreach (var number in Enumerable.Range(0, 100))
        ScoreCollectionList.Add(number);

    IsRefreshing = false;
}
```

### Screenshots

![](https://user-images.githubusercontent.com/13558917/86501165-3f467380-bd4b-11ea-9ca6-506a162cac47.gif)

### Environment

=== Visual Studio Enterprise 2019 for Mac (Preview) ===

Version 8.7 Preview (8.7 build 1802)
Installation UUID: ec012746-7bcc-47bc-bba9-e9b5ade4bdc7
	GTK+ 2.24.23 (Raleigh theme)
	Xamarin.Mac 6.18.0.23 (d16-6 / 088c73638)

	Package version: 612000074

=== Mono Framework MDK ===

Runtime:
	Mono 6.12.0.74 (2020-02/e9d3af508e4) (64-bit)
	Package version: 612000074

=== Roslyn (Language Service) ===

3.7.0-3.20312.3+ec4841263590f5456e32728d98097e97c1605e22

=== NuGet ===

Version: 5.7.0.6653

=== .NET Core SDK ===

SDK: /usr/local/share/dotnet/sdk/5.0.100-preview.6.20318.15/Sdks
SDK Versions:
	5.0.100-preview.6.20318.15
	3.1.301
	3.1.300
	3.1.202
	3.1.200
	3.1.102
	3.0.101
	2.1.803
MSBuild SDKs: /Library/Frameworks/Mono.framework/Versions/6.12.0/lib/mono/msbuild/Current/bin/Sdks

=== .NET Core Runtime ===

Runtime: /usr/local/share/dotnet/dotnet
Runtime Versions:
	5.0.0-preview.6.20305.6
	5.0.0-preview.1.20120.5
	3.1.5
	3.1.4
	3.1.2
	3.1.1
	3.1.0
	3.0.3
	3.0.1
	2.1.19
	2.1.18
	2.1.17
	2.1.16
	2.1.15
	2.1.14

=== Xamarin.Profiler ===

Version: 1.6.13.11
Location: /Applications/Xamarin Profiler.app/Contents/MacOS/Xamarin Profiler

=== Updater ===

Version: 11

=== Apple Developer Tools ===

Xcode 11.5 (16139)
Build 11E608c

=== Xamarin.Mac ===

Version: 6.20.1.18 (Visual Studio Enterprise)
Hash: 8ffa3d888
Branch: d16-7
Build date: 2020-06-06 13:34:07-0400

=== Xamarin.iOS ===

Version: 13.20.1.18 (Visual Studio Enterprise)
Hash: 8ffa3d888
Branch: d16-7
Build date: 2020-06-06 13:34:08-0400

=== Xamarin Designer ===

Version: 16.7.0.459
Hash: 65d9dd3aa
Branch: remotes/origin/d16-7
Build date: 2020-06-10 03:48:34 UTC

=== Xamarin.Android ===

Version: 10.4.0.0 (Visual Studio Enterprise)
Commit: xamarin-android/d16-7/de70286
Android SDK: /Users/bramin/Library/Developer/Xamarin/android-sdk-macosx
	Supported Android versions:
		7.0 (API level 24)
		8.0 (API level 26)
		8.1 (API level 27)

SDK Tools Version: 26.1.1
SDK Platform Tools Version: 30.0.2
SDK Build Tools Version: 29.0.2

Build Information: 
Mono: 87ef555
Java.Interop: xamarin/java.interop/d16-7@76d1ac7
ProGuard: Guardsquare/proguard/proguard6.2.2@ebe9000
SQLite: xamarin/sqlite/3.32.1@1a3276b
Xamarin.Android Tools: xamarin/xamarin-android-tools/d16-7@017078f

=== Microsoft OpenJDK for Mobile ===

Java SDK: /Users/bramin/Library/Developer/Xamarin/jdk/microsoft_dist_openjdk_1.8.0.25
1.8.0-25
Android Designer EPL code available here:
https://github.com/xamarin/AndroidDesigner.EPL

=== Android SDK Manager ===

Version: 16.7.0.8
Hash: 6e20e98
Branch: remotes/origin/d16-7
Build date: 2020-06-11 19:23:34 UTC

=== Android Device Manager ===

Version: 16.7.0.12
Hash: 51b7059
Branch: remotes/origin/d16-7
Build date: 2020-06-11 19:23:58 UTC

=== Build Information ===

Release ID: 807001802
Git revision: 2129f3002481c263b627ea82a6f25349ee5947cb
Build date: 2020-06-22 06:15:44-04
Build branch: release-8.7
Xamarin extensions: 2129f3002481c263b627ea82a6f25349ee5947cb

=== Operating System ===

Mac OS X 10.15.5
Darwin 19.5.0 Darwin Kernel Version 19.5.0
    Tue May 26 20:41:44 PDT 2020
    root:xnu-6153.121.2~2/RELEASE_X86_64 x86_64

