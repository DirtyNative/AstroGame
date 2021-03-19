import 'package:astrogame_app/models/stellar/base_types/stellar_object.dart';
import 'package:astrogame_app/models/stellar/stellar_objects/black_hole.dart';
import 'package:astrogame_app/models/stellar/stellar_objects/moon.dart';
import 'package:astrogame_app/models/stellar/stellar_objects/planet.dart';
import 'package:astrogame_app/models/stellar/stellar_objects/star.dart';
import 'package:json_annotation/json_annotation.dart';

class StellarObjectConverter
    implements JsonConverter<StellarObject, Map<String, dynamic>> {
  const StellarObjectConverter();

  @override
  fromJson(json) {
    var type = json.entries.firstWhere((element) => element.key == '\$type');

    if (type.value == 'Star') {
      return Star.fromJson(json);
    } else if (type.value == 'Planet') {
      return Planet.fromJson(json);
    } else if (type.value == 'Moon') {
      return Moon.fromJson(json);
    } else if (type.value == 'BlackHole') {
      return BlackHole.fromJson(json);
    }

    return null;
  }

  @override
  toJson(object) {
    // TODO: implement toJson
    throw UnimplementedError();
  }
}
