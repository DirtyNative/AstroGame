import 'package:astrogame_app/communications/converters/guid_converter.dart';
import 'package:flutter_guid/flutter_guid.dart';
import 'package:json_annotation/json_annotation.dart';

part 'input_resource.g.dart';

@GuidConverter()
@JsonSerializable()
class InputResource {
  @JsonKey()
  Guid id;

  @JsonKey()
  Guid resourceId;

  @JsonKey()
  Guid buildingId;

  @JsonKey()
  double baseValue;

  @JsonKey()
  double multiplier;

  InputResource();

  factory InputResource.fromJson(Map<String, dynamic> json) =>
      _$InputResourceFromJson(json);
  Map<String, dynamic> toJson() => _$InputResourceToJson(this);
}
