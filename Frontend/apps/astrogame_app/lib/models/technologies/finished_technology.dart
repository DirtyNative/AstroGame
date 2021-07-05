import 'package:astrogame_app/communications/converters/finished_technology_converter.dart';
import 'package:astrogame_app/communications/converters/guid_converter.dart';
import 'package:flutter_guid/flutter_guid.dart';
import 'package:json_annotation/json_annotation.dart';

@GuidConverter()
abstract class FinishedTechnology {
  @JsonKey()
  Guid id;

  @JsonKey()
  Guid technologyId;

  @JsonKey()
  Guid playerId;

  @JsonKey()
  int level;

  FinishedTechnology();

  factory FinishedTechnology.fromJson(Map<String, dynamic> json) =>
      FinishedTechnologyConverter().fromJson(json);
}
