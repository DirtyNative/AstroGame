import 'package:astrogame_app/communications/converters/finished_technology_converter.dart';
import 'package:astrogame_app/communications/converters/guid_converter.dart';
import 'package:astrogame_app/models/common/guid.dart';

import 'package:json_annotation/json_annotation.dart';

@GuidConverter()
abstract class FinishedTechnology {
  @JsonKey()
  late Guid id;

  @JsonKey()
  late Guid technologyId;

  @JsonKey()
  late Guid playerId;

  @JsonKey()
  late int level;

  FinishedTechnology();

  factory FinishedTechnology.fromJson(Map<String, dynamic> json) =>
      FinishedTechnologyConverter().fromJson(json);
}
