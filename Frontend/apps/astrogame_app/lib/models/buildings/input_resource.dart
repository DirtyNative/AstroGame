import 'package:astrogame_app/communications/converters/guid_converter.dart';
import 'package:astrogame_app/models/common/guid.dart';

import 'package:json_annotation/json_annotation.dart';

part 'input_resource.g.dart';

@GuidConverter()
@JsonSerializable()
class InputResource {
  @JsonKey()
  late Guid id;

  @JsonKey()
  late Guid resourceId;

  @JsonKey()
  late Guid buildingId;

  @JsonKey()
  late double baseValue;

  @JsonKey()
  late double multiplier;

  InputResource();

  factory InputResource.fromJson(Map<String, dynamic> json) =>
      _$InputResourceFromJson(json);
  Map<String, dynamic> toJson() => _$InputResourceToJson(this);
}
