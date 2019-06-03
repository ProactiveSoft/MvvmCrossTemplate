## List of Contents
- [List of Contents](#list-of-contents)
- [Tombstoning](#tombstoning)
- [Resources](#resources)



___
___



## Tombstoning

* [Tombstoning][2] is the process when the OS suspends the app in low-memory condition.

```cs
public class MainViewModel : MvxViewModel
{
    protected override void SaveStateToBundle(IMvxBundle bundle)
    {
        base.SaveStateToBundle(bundle);

        bundle.Data["MyKey"] = _counter.ToString();
    }

    protected override void ReloadFromBundle(IMvxBundle state)
    {
        base.ReloadFromBundle(state);

        _counter = int.Parse(state.Data["MyKey"]);
    }
    
    
    private int _counter = 2;
}
```



___
___



## Resources

* [ViewModel Lifecycle][1]
* [Tombstoning][2]














[1]: https://www.mvvmcross.com/documentation/fundamentals/viewmodel-lifecycle "ViewModel Lifecycle - MvvmCross Doc"
[2]: https://www.mvvmcross.com/documentation/fundamentals/viewmodel-lifecycle#tombstoning-saving-and-restoring-the-viewmodels-state "Tombstoning - MvvmCross Doc"