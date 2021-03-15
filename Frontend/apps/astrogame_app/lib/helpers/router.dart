import 'package:astrogame_app/bags/show_planet_view_bag.dart';
import 'package:astrogame_app/helpers/route_paths.dart';
import 'package:astrogame_app/views/planet/planet_view.dart';
import 'package:astrogame_app/views/start/start_view.dart';
import 'package:flutter/material.dart';

Route<dynamic> generateRoute(RouteSettings settings) {
  switch (settings.name) {
    case RoutePaths.StartRoute:
      return MaterialPageRoute(builder: (_) => StartView());

    case RoutePaths.PlanetViewRoute:
      var bag = settings.arguments as ShowPlanetViewBag;

      return MaterialPageRoute(builder: (_) => PlanetView(bag.planet));
  }

  return MaterialPageRoute(
    builder: (_) => Scaffold(
      body: Center(
        child: Text('No path for ${settings.name}'),
      ),
    ),
  );
}
