import 'package:astrogame_app/services/navigation_wrapper.dart';
import 'package:astrogame_app/views/menus/menu_entry.dart';
import 'package:astrogame_app/views/menus/menu_item.dart';
import 'package:flutter/material.dart';

class MenuItemListing extends StatelessWidget {
  final ValueChanged<MenuEntry> itemSelectedCallback;
  final MenuEntry? selectedItem;

  final NavigationWrapper navigationService;

  MenuItemListing(
    this.navigationService,
    this.selectedItem,
    this.itemSelectedCallback,
  );

  @override
  Widget build(BuildContext context) {
    return ListView(
      shrinkWrap: true,
      children: menuEntries.map(
        (item) {
          return MenuItem(
            item.icon,
            item.label,
            (navigationService.currentSubRoute == item.route),
            () => itemSelectedCallback(item),
          );
        },
      ).toList(),
    );
  }
}
