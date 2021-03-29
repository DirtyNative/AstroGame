import 'package:astrogame_app/communications/converters/guid_converter.dart';
import 'package:flutter_guid/flutter_guid.dart';
import 'package:json_annotation/json_annotation.dart';

part 'output_resource.g.dart';

@GuidConverter()
@JsonSerializable()
class OutputResource {
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

  OutputResource();

  factory OutputResource.fromJson(Map<String, dynamic> json) =>
      _$OutputResourceFromJson(json);
  Map<String, dynamic> toJson() => _$OutputResourceToJson(this);
}
