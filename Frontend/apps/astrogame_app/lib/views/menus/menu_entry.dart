import 'package:astrogame_app/helpers/route_paths.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';

class MenuEntry {
  final String label;
  final IconData icon;
  final String route;

  MenuEntry(this.label, this.icon, this.route);
}

final menuEntries = <MenuEntry>[
  MenuEntry(
    'Home',
    Icons.home,
    RoutePaths.HomeRoute,
  ),
  MenuEntry(
    'Resources',
    Icons.restore_outlined,
    RoutePaths.ResourcesRoute,
  ),
  MenuEntry(
    'Buildings',
    Icons.home,
    RoutePaths.BuildingsRoute,
  ),
  MenuEntry(
    'Researches',
    Icons.home,
    RoutePaths.ResearchesRoute,
  ),
  MenuEntry(
    'Systems',
    Icons.system_update,
    RoutePaths.SystemViewRoute,
  ),
  MenuEntry(
    'Galaxy',
    Icons.system_update,
    RoutePaths.GalaxyRoute,
  ),
  MenuEntry(
    'Market',
    Icons.money,
    RoutePaths.MarketRoute,
  ),
  MenuEntry(
    'Species',
    Icons.system_update,
    RoutePaths.NotImplementedRoute,
  ),
  MenuEntry(
    'Empire',
    Icons.system_update,
    RoutePaths.NotImplementedRoute,
  ),
  MenuEntry(
    'Contacts',
    Icons.system_update,
    RoutePaths.NotImplementedRoute,
  ),
  MenuEntry(
    'Alliance',
    Icons.system_update,
    RoutePaths.NotImplementedRoute,
  ),
];
