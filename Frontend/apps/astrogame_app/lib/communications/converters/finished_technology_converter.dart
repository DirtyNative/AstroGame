import 'package:astrogame_app/models/technologies/finished_technology.dart';
import 'package:astrogame_app/models/technologies/player_dependent_finished_technology.dart';
import 'package:astrogame_app/models/technologies/stellar_object_dependent_finished_technology.dart';
import 'package:json_annotation/json_annotation.dart';

class FinishedTechnologyConverter
    implements JsonConverter<FinishedTechnology, Map<String, dynamic>> {
  const FinishedTechnologyConverter();

  @override
  fromJson(json) {
    if (json.containsKey('\$type') == false) {
      throw Exception('json does not contain type key');
    }

    var type = json.entries.firstWhere((element) => element.key == '\$type');

    if (type.value == 'StellarObjectDependentFinishedTechnology') {
      return StellarObjectDependentFinishedTechnology.fromJson(json);
    } else if (type.value == 'PlayerDependentFinishedTechnology') {
      return PlayerDependentFinishedTechnology.fromJson(json);
    }

    return null;
  }

  @override
  toJson(object) {
    throw UnimplementedError();
  }
}
