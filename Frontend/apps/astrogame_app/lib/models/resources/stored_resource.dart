import 'package:astrogame_app/communications/converters/guid_converter.dart';
import 'package:astrogame_app/models/common/guid.dart';

import 'package:json_annotation/json_annotation.dart';

part 'stored_resource.g.dart';

@GuidConverter()
@JsonSerializable()
class StoredResource {
  late Guid id;
  late Guid resourceId;
  late Guid resourceSnapshotId;
  late double amount;
  late double hourlyAmount;

  StoredResource();

  factory StoredResource.fromJson(Map<String, dynamic> json) =>
      _$StoredResourceFromJson(json);
  Map<String, dynamic> toJson() => _$StoredResourceToJson(this);
}
