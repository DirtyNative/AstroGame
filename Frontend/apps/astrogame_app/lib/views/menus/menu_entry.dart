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
    label: 'Resources',
    icon: Icons.restore_outlined,
    route: RoutePaths.ResourcesRoute,
  ),
  MenuEntry(
    label: 'Buildings',
    icon: Icons.home,
    route: RoutePaths.BuildingsRoute,
  ),
  MenuEntry(
    label: 'Researches',
    icon: Icons.home,
    route: RoutePaths.ResearchesRoute,
  ),
  MenuEntry(
    label: 'Systems',
    icon: Icons.system_update,
    route: RoutePaths.SystemViewRoute,
  ),
  MenuEntry(
    label: 'Galaxy',
    icon: Icons.system_update,
    route: RoutePaths.GalaxyRoute,
  ),
  MenuEntry(
    label: 'Market',
    icon: Icons.money,
    route: RoutePaths.MarketRoute,
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
