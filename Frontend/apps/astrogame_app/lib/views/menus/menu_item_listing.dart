import 'package:astrogame_app/views/menus/menu_entry.dart';
import 'package:astrogame_app/views/menus/menu_item.dart';
import 'package:flutter/material.dart';
import 'package:stacked_services/stacked_services.dart';

class MenuItemListing extends StatelessWidget {
  final ValueChanged<MenuEntry> itemSelectedCallback;
  final MenuEntry selectedItem;

  final NavigationService navigationService;

  MenuItemListing({
    @required this.navigationService,
    @required this.itemSelectedCallback,
    this.selectedItem,
  });

  @override
  Widget build(BuildContext context) {
    return Container(
      height: 300,
      child: ListView(
        children: menuEntries.map(
          (item) {
            return MenuItem(
              icon: item.icon,
              label: item.label,
              isSelected: (navigationService.currentRoute == item.route),
              onTap: () => itemSelectedCallback(item),
            );
          },
        ).toList(),
      ),
    );
  }
}
