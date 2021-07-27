import 'package:astrogame_app/communications/converters/condition_converter.dart';
import 'package:astrogame_app/communications/converters/guid_converter.dart';
import 'package:astrogame_app/models/common/guid.dart';

@GuidConverter()
abstract class Condition {
  late Guid id;
  late Guid technologyId;
  late Guid neededTechnologyId;

  Condition();

  factory Condition.fromJson(Map<String, dynamic> json) =>
      ConditionConverter().fromJson(json);
  Map<String, dynamic> toJson() => ConditionConverter().toJson(this);
}
