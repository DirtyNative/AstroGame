import 'package:astrogame_app/models/conditions/condition.dart';
import 'package:astrogame_app/models/conditions/levelable_condition.dart';
import 'package:astrogame_app/models/conditions/one_time_condition.dart';
import 'package:json_annotation/json_annotation.dart';

class ConditionConverter
    implements JsonConverter<Condition, Map<String, dynamic>> {
  const ConditionConverter();

  @override
  fromJson(json) {
    if (json.containsKey('\$type') == false) {
      throw Exception('json does not contain type key');
    }

    var type = json.entries.firstWhere((element) => element.key == '\$type');

    if (type.value == 'OneTimeCondition') {
      return OneTimeCondition.fromJson(json);
    } else if (type.value == 'LevelableCondition') {
      return LevelableCondition.fromJson(json);
    }

    throw new UnimplementedError('Condition is not yet implemented');
  }

  @override
  toJson(object) {
    throw UnimplementedError();
  }
}
