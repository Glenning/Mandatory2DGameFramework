Notes for considerations I made during the development of this:
How do I deal with creatures with no HP?
  - Have all creatures in a list, when create HP < 1 remove from list
  - Make a separate list for dead creatures
  - INotifyPropertyChanged to observe HP
  - States
