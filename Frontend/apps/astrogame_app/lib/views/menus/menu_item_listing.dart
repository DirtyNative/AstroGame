import 'package:astrogame_app/services/navigation_wrapper.dart';
import 'package:astrogame_app/views/menus/menu_entry.dart';
import 'package:astrogame_app/views/menus/menu_item.dart';
import 'package:flutter/material.dart';

class MenuItemListing extends StatelessWidget {
  final ValueChanged<MenuEntry> itemSelectedCallback;
  final MenuEntry selectedItem;

  final NavigationWrapper navigationService;

  MenuItemListing({
    @required this.navigationService,
    @required this.itemSelectedCallback,
    this.selectedItem,
  });

  @override
  Widget build(BuildContext context) {
    return ListView(
      shrinkWrap: true,
      children: menuEntries.map(
        (item) {
          return MenuItem(
            icon: item.icon,
            label: item.label,
            isSelected: (navigationService.currentSubRoute == item.route),
            onTap: () => itemSelectedCallback(item),
          );
        },
      ).toList(),
    );
  }
}
