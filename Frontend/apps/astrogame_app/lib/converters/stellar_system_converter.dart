import 'package:astrogame_app/models/stellar/base_types/stellar_system.dart';
import 'package:astrogame_app/models/stellar/systems/multi_object_system.dart';
import 'package:astrogame_app/models/stellar/systems/solar_system.dart';
import 'package:json_annotation/json_annotation.dart';

class StellarSystemConverter
    implements JsonConverter<StellarSystem, Map<String, dynamic>> {
  const StellarSystemConverter();

  @override
  fromJson(json) {
    if (json == null) {
      return null;
    }

    var type = json.entries.firstWhere((element) => element.key == '\$type');

    if (type.value == 'MultiObjectSystem') {
      return MultiObjectSystem.fromJson(json);
    } else if (type.value == 'SolarSystem') {
      return SolarSystem.fromJson(json);
    }
    return null;
  }

  @override
  toJson(object) {
    // TODO: implement toJson
    throw UnimplementedError();
  }
}
