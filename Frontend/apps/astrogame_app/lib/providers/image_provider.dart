import 'package:flutter/widgets.dart';
import 'package:injectable/injectable.dart';

enum ImageScope {
  building,
  research,
  species,
  stellarObject,
}

@singleton
class AssetImageProvider {
  AssetImageProvider();

  ImageProvider get(String assetName, ImageScope scope) {
    String scopePath = '';

    if (scope == ImageScope.building) {
      scopePath = 'buildings';
    } else if (scope == ImageScope.research) {
      scopePath = 'researches';
    } else if (scope == ImageScope.species) {
      scopePath = 'species';
    } else if (scope == ImageScope.stellarObject) {
      scopePath = 'stellar_objects';
    } else {
      throw new UnimplementedError(
          'ImageScope ${scope} is not implemented yet');
    }

    return AssetImage('assets/images/${scopePath}/${assetName}');
  }
}
