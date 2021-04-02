import 'package:astrogame_app/helpers/route_paths.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';

class MenuEntry {
  final String label;
  final IconData icon;
  final String route;

  MenuEntry({@required this.label, @required this.icon, this.route});
}

final menuEntries = <MenuEntry>[
  MenuEntry(
    label: 'Home',
    icon: Icons.home,
    route: RoutePaths.HomeRoute,
  ),
  MenuEntry(
    label: 'Buildings',
    icon: Icons.home,
    route: RoutePaths.BuildingsRoute,
  ),
  MenuEntry(
    label: 'Systems',
    icon: Icons.system_update,
    route: RoutePaths.SystemViewRoute,
  ),
  MenuEntry(
    label: 'Species',
    icon: Icons.system_update,
    route: RoutePaths.NotImplementedRoute,
  ),
  MenuEntry(
    label: 'Empire',
    icon: Icons.system_update,
    route: RoutePaths.NotImplementedRoute,
  ),
  MenuEntry(
    label: 'Contacts',
    icon: Icons.system_update,
    route: RoutePaths.NotImplementedRoute,
  ),
  MenuEntry(
    label: 'Alliance',
    icon: Icons.system_update,
    route: RoutePaths.NotImplementedRoute,
  ),
];
