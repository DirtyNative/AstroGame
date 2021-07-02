import 'package:astrogame_app/communications/converters/condition_converter.dart';
import 'package:astrogame_app/communications/converters/guid_converter.dart';
import 'package:astrogame_app/models/base_types/technology.dart';
import 'package:flutter_guid/flutter_guid.dart';

@GuidConverter()
abstract class Condition {
  Guid id;
  Guid technologyId;
  Guid neededTechnologyId;
  Technology technology;
  Technology neededTechnology;

  Condition();

  factory Condition.fromJson(Map<String, dynamic> json) =>
      ConditionConverter().fromJson(json);
  Map<String, dynamic> toJson() => ConditionConverter().toJson(this);
}
