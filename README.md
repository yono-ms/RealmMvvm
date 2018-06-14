# RealmMvvm
Mvvm using Realm.

## Version

VisualStudio2017

## History

1. /Xamarin/UWP/.NetStandardの構成でスタート
1. RealmをNuGet
1. UWPで.NetStandardのデバッグ不可
1. SharedProjectに移行
1. XamarinでAnnotationを使用不可
1. .NetStandardを再追加して既存リンク参照
1. SharedProject削除.NetStandardに実体UWPから既存リンク参照
1. Realmを.NetStandardとXamarin両方に入れる
1. FodyWeavers.xmlは両方に必要
1. SolutionDir警告は一回再起動すると消える

## Tips

- Realm+.NetStandard+UWPではデバッグ不可
- Annotationを使用するにはXamarin+.NetStandard必須
- SharedProjectであればUWPからデバッグ可能
  - 既存参照でフォルダつくれば良いのでは
- 現在までのすべての構成でd:DesignInstanceは不可
- Realm+Xamarinでは.NetStandard必須
