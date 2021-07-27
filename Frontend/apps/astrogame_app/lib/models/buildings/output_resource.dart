import 'package:astrogame_app/communications/converters/guid_converter.dart';
import 'package:astrogame_app/models/common/guid.dart';

import 'package:json_annotation/json_annotation.dart';

part 'output_resource.g.dart';

@GuidConverter()
@JsonSerializable()
class OutputResource {
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

  OutputResource();

  factory OutputResource.fromJson(Map<String, dynamic> json) =>
      _$OutputResourceFromJson(json);
  Map<String, dynamic> toJson() => _$OutputResourceToJson(this);
}
