# RealmMvvm
Mvvm using Realm.

## Version

VisualStudio2017

## History

1. /Xamarin/UWP/.NetStandardの構成でスタート
2. RealmをNuGet
3. UWPで.NetStandardのデバッグ不可
4. SharedProjectに移行
5. XamarinでAnnotationを使用不可
6. .NetStandardを再追加して既存参照

## Tips

- Realm+.NetStandard+UWPではデバッグ不可
- Annotationを使用するにはXamarin+.NetStandard必須
- SharedProjectであればUWPからデバッグ可能
  - 既存参照でフォルダつくれば良いのでは
- 現在までのすべての構成でd:DesignInstanceは不可

